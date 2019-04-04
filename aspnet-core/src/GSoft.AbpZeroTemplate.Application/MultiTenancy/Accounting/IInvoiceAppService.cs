using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy.Accounting.Dto;

namespace GSoft.AbpZeroTemplate.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
