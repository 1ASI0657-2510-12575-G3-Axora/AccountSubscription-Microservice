using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public record GetAccountDetailsQuery(
        [Required] int AccountId
        );
}