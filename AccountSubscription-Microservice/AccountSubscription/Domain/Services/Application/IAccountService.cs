using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;

namespace DittoBox.API.AccountSubscription.Domain.Services.Application
{
    public interface IAccountService
    {
		public Task<Account> CreateAccount(int representativeId, string businessName, string businessId);
		public Task<Account?> GetAccount(int accountId);
		public Task UpdateAccountRepresentative(int accountId, int representativeId);
		public Task UpdateAccountBusinessInformation(int accountId, string businessName, string businessId);
    }
}
