using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IGetSubscriptionDetailsQueryHandler
    {
        public Task<SubscriptionResource?> Handle(GetSubscriptionDetailsQuery query);
    }
}
