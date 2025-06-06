using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class AccountService(
		IAccountRepository accountRepository
	) : IAccountService
	{
		public async Task<Account> CreateAccount(int representativeId, string businessName, string businessId)
		{
			var account = new Account()
			{
				RepresentativeId = representativeId,
				BusinessName = businessName,
				BusinessId = businessId
			};

			await accountRepository.Add(account);
			return account;
		}

		public async Task<Account?> GetAccount(int accountId)
		{
			return await accountRepository.GetById(accountId);
		}
		public async Task UpdateAccountRepresentative(int accountId, int representativeId)
		{
			var account = await accountRepository.GetById(accountId);
			if (account != null)
			{
				account.RepresentativeId = representativeId;
				await accountRepository.Update(account);
			}
		}

		public async Task UpdateAccountBusinessInformation(int accountId, string businessName, string businessId)
		{
			var account = await accountRepository.GetById(accountId);
			if (account != null)
			{
				account.BusinessName = businessName;
				account.BusinessId = businessId;
				await accountRepository.Update(account);
			}
		}
	}
}
