using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Errors;
using InvoiceManager.Api.Features.Invoices.V1.Querys.GetAll;
using InvoiceManager.Api.Persistence.Query.Context;
using InvoiceManager.Api.Persistence.QueryContext.QueryModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Api.Features.Invoices.V1.Queries.GetAll
{
    public sealed class Handler(QueryDbContext dbContext) : IRequestHandler<Query, AppResponse<List<InvoiceModel>>>
    {
        private readonly QueryDbContext _dbContext = dbContext;

        public async Task<AppResponse<List<InvoiceModel>>> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _dbContext.Invoices.AsQueryable();

                if (request.DeliveredSince is not null)
                    query = query.Where(x => x.DeliveredAt > request.DeliveredSince);

                if (request.DeliveredTo is not null)
                    query = query.Where(x => x.DeliveredAt < request.DeliveredTo);

                if (request.InvoiceNumberSince is not null)
                    query = query.Where(x => x.InvoiceNumber > request.InvoiceNumberSince);

                if (request.InvoiceNumberTo is not null)
                    query = query.Where(x => x.InvoiceNumber < request.InvoiceNumberTo);

                if (request.ProductId is not null)
                    query = query.Where(x => x.ProductId == request.ProductId);

                if (request.SchoolId is not null)
                    query = query.Where(x => x.SchoolId == request.SchoolId);

                if (request.ContractId is not null)
                    query = query.Where(x => x.ContractId == request.ContractId);

                if (!string.IsNullOrEmpty(request.Order))
                {
                    query = request.OrderDesc
                        ? query.OrderByDescending(e => EF.Property<object>(e, request.Order))
                        : query.OrderBy(e => EF.Property<object>(e, request.Order));
                }

                var invoices = await query.ToListAsync(cancellationToken);

                return AppResponse.Success()
                                  .WithData(invoices);
            }
            catch (Exception ex)
            {
                Error.Unexpected.InternalServerError().Trow(ex);
                throw;
            }
        }
    }
}
