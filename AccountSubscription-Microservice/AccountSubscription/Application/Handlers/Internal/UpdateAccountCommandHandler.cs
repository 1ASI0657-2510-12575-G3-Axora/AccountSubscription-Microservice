using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class UpdateAccountCommandHandler(
		IAccountService accountService,
		IUnitOfWork unitOfWork
	) : IUpdateAccountCommandHandler
    {
        public async Task Handle(UpdateAccountCommand command)
        {
			await accountService.UpdateAccountRepresentative(command.AccountId, command.RepresentativeId);
			await unitOfWork.CompleteAsync();
        }
    }
}
