using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IDowngradeSubscriptionCommandHandler
    {
        public Task Handle(DowngradeSubscriptionCommand command);
    }
}
