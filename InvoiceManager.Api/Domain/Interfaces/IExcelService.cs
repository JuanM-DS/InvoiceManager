using InvoiceManager.Api.Shared.Dtos;

namespace InvoiceManager.Api.Domain.Interfaces
{
    public interface IExcelService
    {
        public byte[] GenerateExcelFile(List<InvoiceTemplateDto> modeltemplates);
    }
}
