using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class CancelSubscriptionCommandHandler(
		ISubscriptionService subscriptionService
	) : ICancelSubscriptionCommandHandler
    {
        public async Task Handle(CancelSubscriptionCommand command)
        {
			await subscriptionService.DeleteSubscription(command.SubscriptionId);
        }
    }
}
