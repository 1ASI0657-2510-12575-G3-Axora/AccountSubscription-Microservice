using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface ICreateAccountCommandHandler
    {
        public Task<AccountResource> Handle(CreateAccountCommand command);
    }
}
