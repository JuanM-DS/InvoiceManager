using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Errors;
using InvoiceManager.Api.Domain.Structs;
using InvoiceManager.Api.Persistence.Command.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InvoiceManager.Api.Features.Invoices.V1.Commands.Create
{
    public sealed class CreateInvoiceCommandHandler(CommandDbContext dbContext) : IRequestHandler<CreateInvoiceCommand, AppResponse<Empty>>
    {
        private readonly CommandDbContext _dbContext = dbContext;

        public async Task<AppResponse<Empty>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var schoolIds = request.Invoices.Select(x => x.SchoolId).Distinct();
                var supplierIds = request.Invoices.Select(x => x.SupplierId).Distinct();
                var productIds = request.Invoices.Select(x => x.ProductId).Distinct();
                var contractIds = request.Invoices.Select(x => x.ContractId).Distinct();

                var schoolsTask = _dbContext.Schools
                    .Where(x => schoolIds.Contains(x.Id))
                    .ToDictionaryAsync(x => x.Id, cancellationToken);

                var suppliersTask = _dbContext.Suppliers
                    .Where(x => supplierIds.Contains(x.Id))
                    .ToDictionaryAsync(x => x.Id, cancellationToken);

                var productsTask = _dbContext.Products
                    .Where(x => productIds.Contains(x.Id))
                    .ToDictionaryAsync(x => x.Id, cancellationToken);

                var contractSchoolsTask = _dbContext.contractSchools
                    .Where(x => contractIds.Contains(x.ContractId))
                    .ToListAsync(cancellationToken);

                await Task.WhenAll(schoolsTask, suppliersTask, productsTask, contractSchoolsTask);

                var schools = schoolsTask.Result;
                var suppliers = suppliersTask.Result;
                var products = productsTask.Result;
                var contractSchools = contractSchoolsTask.Result;

                // grouping per day (business rule)
                var invoicesPerDay = request.Invoices.GroupBy(x => x.DeliveredAt);

                foreach (var dayGroup in invoicesPerDay)
                {
                    int? previousOrder = null;

                    foreach (var invoice in dayGroup)
                    {
                        // school validation
                        if (!schools.TryGetValue(invoice.SchoolId, out var school))
                            return AppError.Create("The school does not exist")
                                .For<CreateInvoiceItem>(x => x.SchoolId)
                                .Badrequest();

                        // supplier validation
                        if (!suppliers.ContainsKey(invoice.SupplierId))
                            return AppError.Create("The supplier does not exist")
                                .For<CreateInvoiceItem>(x => x.SupplierId)
                                .Badrequest();

                        // product validation
                        if (!products.ContainsKey(invoice.ProductId))
                            return AppError.Create("The product does not exist")
                                .For<CreateInvoiceItem>(x => x.ProductId)
                                .Badrequest();

                        var exisinovice = await _dbContext.Invoices.FirstOrDefaultAsync(x =>
                            x.SchoolId == invoice.SchoolId &&
                            x.ContractId == invoice.ContractId &&
                            x.DeliveredAt == invoice.DeliveredAt,
                            cancellationToken);

                        if (exisinovice is not null)
                            return AppError.Create($"This invoice: {exisinovice.InvoiceNumber} already exists ")
                                .For<CreateInvoiceItem>(x => x.SchoolId)
                                .Badrequest();

                        // business rule: rations limit
                        if (invoice.RationsDelivered > school.RationsNumber)
                            return AppError.Create(
                                    $"Delivered rations must not exceed assigned rations: {school.RationsNumber}")
                                .For<CreateInvoiceItem>(x => x.RationsDelivered)
                                .Badrequest();

                        // contract order validation
                        var currentSchoolOrder = contractSchools
                            .FirstOrDefault(x =>
                                x.ContractId == invoice.ContractId &&
                                x.SchoolId == invoice.SchoolId)
                            ?.SchoolOrder;

                        if (currentSchoolOrder is null)
                            return AppError.Create("School is not part of the contract")
                                .For<CreateInvoiceItem>(x => x.SchoolId)
                                .Badrequest();

                        if (previousOrder.HasValue && previousOrder.Value != currentSchoolOrder - 1)
                            return AppError.Create(
                                    $"The order of schools for {invoice.DeliveredAt} is wrong")
                                .For<CreateInvoiceItem>(x => x.SchoolId)
                                .Badrequest();

                        previousOrder = currentSchoolOrder;
                    }
                }

                await _dbContext.Invoices.AddRangeAsync(request.Invoices.Map(), cancellationToken);

                var result = await _dbContext.SaveChangesAsync(cancellationToken);

                return result > 0
                    ? AppResponse.Success().Empty().WithCode(HttpStatusCode.Created)
                    : AppError.Create("Has been an error while creating the invoices")
                        .InternalServerError();
            }
            catch (Exception ex)
            {
                AppError.Create("Has been an error while creating the invoices")
                    .InternalServerError()
                    .Trow(ex);

                return null!;
            }
        }
    }
}
