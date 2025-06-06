using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class DeleteAccountCommandHandler(
		ISubscriptionService subscriptionService,
		IUnitOfWork unitOfWork
	) : IDeleteAccountCommandHandler
    {
        public async Task Handle(DeleteAccountCommand command)
        {
			var subscription = await subscriptionService.GetSubscription(command.AccountId);
			if (subscription != null)
			{
				await subscriptionService.DeleteSubscription(command.AccountId);
				await unitOfWork.CompleteAsync();
			}
        }
    }
}
