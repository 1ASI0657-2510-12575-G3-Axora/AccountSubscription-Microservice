using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetAccountDetailsQueryHandler(
		IAccountService accountService
	) : IGetAccountDetailsQueryHandler
    {
        public async Task<AccountResource?> Handle(GetAccountDetailsQuery query)
        {

			var result = await accountService.GetAccount(query.AccountId);
			return result == null ? null : AccountResource.FromAccount(result);
        }
    }
}
