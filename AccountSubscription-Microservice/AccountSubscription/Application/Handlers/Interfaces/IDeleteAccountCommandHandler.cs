using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IDeleteAccountCommandHandler
    {
        public Task Handle(DeleteAccountCommand command);
    }
}
