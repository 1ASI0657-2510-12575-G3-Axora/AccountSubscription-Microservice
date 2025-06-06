using DittoBox.API.AccountSubscription.Domain.Models.ValueObjects;

namespace DittoBox.API.AccountSubscription.Domain.Services.Domain {
	public interface IAccountManagementService {
		Task UpgradeSubscription(string accountId, SubscriptionTier tier);
		Task DowngradeSubscription(string accountId, SubscriptionTier tier);
		Task CancelSubscription(string accountId);
		Task UpdateBusinessInformation(string accountId, string businessName, string businessEmail);
		Task UpdateRepresentative(string accountId, string representativeName, string representativeEmail);
	}
}