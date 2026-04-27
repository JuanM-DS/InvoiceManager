using InvoiceManager.Api.Application.Wrappers;
using InvoiceManager.Api.Domain.Structs;
using InvoiceManager.Api.Features.Abstractions;
using MediatR;

namespace InvoiceManager.Api.Features.Invoices.V1.Commands.Create
{
    public static class Endpoint
    {
        public partial class PartialEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder group)
            {
                group.MapPost("/Invoices", Handler)
                    .WithName("CreateInvoice")
                    .WithTags("Invoices")
                    .HasApiVersion(1.0)
                    .Accepts<AppResponse<Empty>>("application/json")
                    .Produces(StatusCodes.Status201Created)
                    .Produces(StatusCodes.Status400BadRequest)
                    .Produces(StatusCodes.Status500InternalServerError);
            }
        }

        public static async Task<IResult> Handler(Command command, IMediator mediator)
        {
            var response = await mediator.Send(command);
            return Results.Json(response, statusCode: (int)response.HttpStatusCode);
        }
    }
}
