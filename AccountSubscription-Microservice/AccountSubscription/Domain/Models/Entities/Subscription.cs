namespace DittoBox.API.AccountSubscription.Domain.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
		public int AccountId { get; set; }
        public int TierId { get; set; }
        public DateOnly PaymentDate { get; set; }
        public int SubscriptionStatusId { get; set; }
        public DateOnly LastPaidPeriod { get; set; }

        public Subscription()
        {
        }
        public Subscription(int id, int tierId, DateOnly paymentDate, int subscriptionStatusId, DateOnly lastPaidPeriod)
        {
            Id = id;
            TierId = tierId;
            PaymentDate = paymentDate;
            SubscriptionStatusId = subscriptionStatusId;
            LastPaidPeriod = lastPaidPeriod;
        }
    }
}
