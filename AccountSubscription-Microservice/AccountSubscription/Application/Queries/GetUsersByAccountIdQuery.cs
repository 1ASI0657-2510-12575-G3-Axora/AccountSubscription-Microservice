using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public record GetUsersByAccountIdQuery(
        [Required] int AccountId
    );
}