using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IUpdateAccountCommandHandler
    {
        public Task Handle(UpdateAccountCommand command);
    }
}
