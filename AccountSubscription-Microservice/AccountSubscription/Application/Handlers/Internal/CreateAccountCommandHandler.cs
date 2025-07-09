using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Resources;
using DittoBox.API.AccountSubscription.Domain.Services.Application;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Internal
{
    public class CreateAccountCommandHandler(IAccountService accountService) : ICreateAccountCommandHandler
    {
        public async Task<AccountResource> Handle(CreateAccountCommand command)
        {
            var account = await accountService.CreateAccount(
                command.RepresentativeId,
                command.BusinessName,
                command.BusinessId
            );

            return AccountResource.FromAccount(account);
        }
    }
}