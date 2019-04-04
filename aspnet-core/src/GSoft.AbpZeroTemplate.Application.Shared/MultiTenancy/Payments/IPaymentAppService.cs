using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.MultiTenancy.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy.Payments.Dto;
using Abp.Application.Services.Dto;

namespace GSoft.AbpZeroTemplate.MultiTenancy.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<PaymentInfoDto> GetPaymentInfo(PaymentInfoInput input);

        Task<CreatePaymentResponse> CreatePayment(CreatePaymentDto input);

        Task<ExecutePaymentResponse> ExecutePayment(ExecutePaymentDto input);

        Task<PagedResultDto<SubscriptionPaymentListDto>> GetPaymentHistory(GetPaymentHistoryInput input);
    }
}
