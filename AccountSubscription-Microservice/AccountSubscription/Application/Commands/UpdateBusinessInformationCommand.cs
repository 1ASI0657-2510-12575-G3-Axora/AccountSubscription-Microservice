using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.AccountSubscription.Application.Commands
{
    public record UpdateBusinessInformationCommand
    (
        [Required] int AccountId,
        [Required] string BusinessName,
        [Required] string BusinessId
        );
}