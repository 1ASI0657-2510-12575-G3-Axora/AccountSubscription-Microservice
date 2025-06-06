using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IUpgradeSubscriptionCommandHandler
    {
        public Task Handle(UpgradeSubscriptionCommand command);
    }
}
