using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record CancelSubscriptionCommand
    {
        [Required]
        public int SubscriptionId { get; init; }
    }
}