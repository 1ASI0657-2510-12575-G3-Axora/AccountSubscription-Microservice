using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class DowngradeSubscriptionCommandHandler(
		ISubscriptionService subscriptionService,
		IUnitOfWork unitOfWork
	) : IDowngradeSubscriptionCommandHandler
    {
        public async Task Handle(DowngradeSubscriptionCommand command)
        {
			await subscriptionService.UpdateSubscriptionTier(command.SubscriptionId, command.NewTierId);
			await unitOfWork.CompleteAsync();
        }
    }
}
