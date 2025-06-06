namespace DittoBox.API.AccountSubscription.Domain.Models.ValueObjects
{
    public enum SubscriptionStatus
    {
        Active = 0,
        Canceled = 1,
        Expired = 2
    }

    public static class SubscriptionStatusExtensions
    {
        public static string ToString(this SubscriptionStatus status)
        {
            return status switch
            {
                SubscriptionStatus.Active => "Active",
                SubscriptionStatus.Canceled => "Canceled",
                SubscriptionStatus.Expired => "Expired",
                _ => "Unknown"
            };
        }
    }
}