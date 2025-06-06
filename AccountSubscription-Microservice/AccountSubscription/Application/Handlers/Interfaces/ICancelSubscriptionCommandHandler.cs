using DittoBox.API.AccountSubscription.Application.Commands;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface ICancelSubscriptionCommandHandler
    {
        public Task Handle(CancelSubscriptionCommand command);
    }
}
