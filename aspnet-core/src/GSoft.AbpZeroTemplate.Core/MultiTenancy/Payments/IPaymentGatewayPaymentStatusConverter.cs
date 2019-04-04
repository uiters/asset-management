namespace GSoft.AbpZeroTemplate.MultiTenancy.Payments
{
    public interface IPaymentGatewayPaymentStatusConverter
    {
        SubscriptionPaymentStatus ConvertToSubscriptionPaymentStatus(string externalStatus);
    }
}