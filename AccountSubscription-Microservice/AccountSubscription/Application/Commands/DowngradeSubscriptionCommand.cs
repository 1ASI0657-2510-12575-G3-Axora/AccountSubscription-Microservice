using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record DowngradeSubscriptionCommand
    {
        [Required]
        public int SubscriptionId { get; init; }
        [Required]
        public int NewTierId { get; init; }
    }
}