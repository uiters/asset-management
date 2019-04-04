using Abp.AutoMapper;
using GSoft.AbpZeroTemplate.Editions;
using GSoft.AbpZeroTemplate.MultiTenancy.Payments.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}