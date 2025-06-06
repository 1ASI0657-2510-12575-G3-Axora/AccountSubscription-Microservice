using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public record GetGroupsByAccountIdQuery(
        [Required] int AccountId
    );
}