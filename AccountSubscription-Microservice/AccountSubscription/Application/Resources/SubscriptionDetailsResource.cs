namespace DittoBox.API.AccountSubscription.Application.Resources
{
    public record SubscriptionDetailsResource(
        int Id,
        string SubscriptionTier,
        DateOnly PaymentDate,
        string SubscriptionStatus,
        DateOnly LastPaidPeriod
        );

}
