using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Services
{
	public class AccountService(
		IAccountRepository accountRepository,
		IUnitOfWork unitOfWork
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
			await unitOfWork.CompleteAsync();
			
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
				await unitOfWork.CompleteAsync();
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
				await unitOfWork.CompleteAsync();
			}
		}
		
		public async Task<AccountUsageResource> GetSubscriptionUsage(int accountId)
		{
			var account = await accountRepository.GetById(accountId);
			if (account == null)
			{
				throw new Exception("Account not found");
			}

			return new AccountUsageResource
			{
				AccountId = account.Id,
				CurrentPlan = "Standard",
				LowerPlan = "Basic",
				UpperPlan = "Premium",
				Users = new Usage
				{
					Current = 10,
					CurrentLimit = 100,
					LowerPlanLimit = 50,
					UpperPlanLimit = 200
				},
				Containers = new Usage
				{
					Current = 5,
					CurrentLimit = 20,
					LowerPlanLimit = 10,
					UpperPlanLimit = 40
				},
				Facilities = new Usage
				{
					Current = 2,
					CurrentLimit = 10,
					LowerPlanLimit = 5,
					UpperPlanLimit = 15
				}
			};
		}
	}
}
