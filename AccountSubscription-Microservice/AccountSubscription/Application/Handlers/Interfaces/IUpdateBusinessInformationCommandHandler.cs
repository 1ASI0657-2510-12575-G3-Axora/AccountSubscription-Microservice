using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IUpdateBusinessInformationCommandHandler
    {
        public Task Handle(UpdateBusinessInformationCommand command);
    }
}
