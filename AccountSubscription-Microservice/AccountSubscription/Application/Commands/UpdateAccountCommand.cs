using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record UpdateAccountCommand
    (
        [Required] int AccountId,
		[Required] int RepresentativeId
        );
}