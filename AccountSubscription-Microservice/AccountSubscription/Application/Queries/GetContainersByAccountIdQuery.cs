using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Queries
{
    public record GetContainersByAccountIdQuery(
        [Required] int AccountId
    );
}