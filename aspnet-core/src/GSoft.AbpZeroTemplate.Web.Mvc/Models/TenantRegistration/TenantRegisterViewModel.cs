using GSoft.AbpZeroTemplate.Editions;
using GSoft.AbpZeroTemplate.Editions.Dto;
using GSoft.AbpZeroTemplate.Security;
using GSoft.AbpZeroTemplate.MultiTenancy.Payments;
using GSoft.AbpZeroTemplate.MultiTenancy.Payments.Dto;

namespace GSoft.AbpZeroTemplate.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType? Gateway { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public bool ShowPaymentExpireNotification()
        {
            return !string.IsNullOrEmpty(PaymentId);
        }
    }
}
