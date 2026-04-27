namespace InvoiceManager.Api.Features.Abstractions
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder group);
    }
}
