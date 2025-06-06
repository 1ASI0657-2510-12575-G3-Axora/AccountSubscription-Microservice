using DittoBox.API.AccountSubscription.Domain.Models.Entities;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class SubscriptionService(
		ISubscriptionRepository subscriptionRepository
	) : ISubscriptionService
	{
		public async Task<Subscription> CreateSubscription(int accountId)
		{
			var subscription = new Subscription(){
				AccountId = accountId,
				TierId = 0,
				PaymentDate = DateOnly.FromDateTime(DateTime.Now),
				SubscriptionStatusId = 1,
				LastPaidPeriod = DateOnly.FromDateTime(DateTime.Now)
			};
			await subscriptionRepository.Add(subscription);
			return subscription;
		}

		public async Task DeleteSubscription(int subscriptionId)
		{
			var subscription = await GetSubscription(subscriptionId);
			if (subscription != null ){
				await subscriptionRepository.Delete(subscription);
			}
		}

		public async Task<Subscription?> GetSubscription(int subscriptionId)
		{
			return await subscriptionRepository.GetById(subscriptionId);
		}

		public async Task UpdateSubscriptionTier(int subscriptionId, int subscriptionTierId)
		{
			var subscription = await GetSubscription(subscriptionId);
			if (subscription != null ) {
				subscription.TierId = subscriptionTierId;
				await subscriptionRepository.Update(subscription);
			}
		}
	}
}
