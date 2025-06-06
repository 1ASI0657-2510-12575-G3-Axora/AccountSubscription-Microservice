using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public record GetSubscriptionDetailsQuery
    (
        [Required] int SubscriptionId
        );
}