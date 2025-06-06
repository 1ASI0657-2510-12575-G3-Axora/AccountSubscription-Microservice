using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record DeleteAccountCommand
    (
        [Required] int AccountId
    );
}
