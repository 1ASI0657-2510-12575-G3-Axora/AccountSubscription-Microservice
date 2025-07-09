using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetSubscriptionUsageQueryHandler(IAccountService accountService) : IGetSubscriptionUsageQueryHandler
    {
        public async Task<AccountUsageResource> Handle(GetSubscriptionUsageQuery query)
        {
            return await accountService.GetSubscriptionUsage(query.AccountId);
        }
    }
}