using GSoft.AbpZeroTemplate.Editions;
using GSoft.AbpZeroTemplate.MultiTenancy.Payments;

namespace GSoft.AbpZeroTemplate.Web.Models.Payment
{
    public class CreatePaymentModel
    {
        public int EditionId { get; set; }

        public PaymentPeriodType? PaymentPeriodType { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}
