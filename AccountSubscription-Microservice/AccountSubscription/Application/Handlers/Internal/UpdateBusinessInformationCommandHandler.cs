using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class UpdateBusinessInformationCommandHandler(
		IAccountService accountService,
		IUnitOfWork unitOfWork
	) : IUpdateBusinessInformationCommandHandler
    {
        public async Task Handle(UpdateBusinessInformationCommand command)
        {
			await accountService.UpdateAccountBusinessInformation(command.AccountId, command.BusinessName, command.BusinessId);
			await unitOfWork.CompleteAsync();
		}
    }
}
