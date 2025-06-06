using DittoBox.API.AccountSubscription.Domain.Models.Entities;

namespace DittoBox.API.AccountSubscription.Domain.Services.Application
{
    public interface ISubscriptionService
    {
		public Task<Subscription> CreateSubscription(int accountId);
		public Task DeleteSubscription(int subscriptionId);
		public Task<Subscription?> GetSubscription(int subscriptionId);
		public Task UpdateSubscriptionTier(int subscriptionId, int subscriptionTierId);
    }
}
