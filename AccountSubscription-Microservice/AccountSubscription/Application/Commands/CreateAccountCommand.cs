using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record CreateAccountCommand
    (
        [Required] string BusinessName,
        [Required] string BusinessId,
        [Required] int RepresentativeId
    );
}