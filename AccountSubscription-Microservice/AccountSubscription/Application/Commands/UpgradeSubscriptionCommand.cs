using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record UpgradeSubscriptionCommand
    {
        [Required] public int SubscriptionId { get; init; }
        [Required] public int NewTierId { get; init; }
    }
}