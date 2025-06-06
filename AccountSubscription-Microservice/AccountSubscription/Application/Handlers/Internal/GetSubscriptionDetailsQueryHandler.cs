using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Models.ValueObjects;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class GetSubscriptionDetailsQueryHandler(
		ISubscriptionService subscriptionService
		)
		 : IGetSubscriptionDetailsQueryHandler
    {
        public async Task<SubscriptionResource?> Handle(GetSubscriptionDetailsQuery query)
        {
			var details =  await subscriptionService.GetSubscription(query.SubscriptionId);
			return details == null ? null : SubscriptionResource.FromSubscription(details);
        }
    }
}
