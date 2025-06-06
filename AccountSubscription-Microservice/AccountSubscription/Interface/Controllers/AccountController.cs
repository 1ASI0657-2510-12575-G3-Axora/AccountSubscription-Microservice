using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
   /// <summary>
    /// Controller for managing account subscriptions and related operations.
    /// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class AccountController(
		ILogger<AccountController> _logger,
		ICreateAccountCommandHandler createAccountCommandHandler,
		IGetAccountDetailsQueryHandler getAccountDetailsQueryHandler,
		IUpdateAccountCommandHandler updateAccountCommandHandler,
		IDeleteAccountCommandHandler deleteAccountCommandHandler,
		IUpdateBusinessInformationCommandHandler updateBusinessInformationCommandHandler,
		IGetSubscriptionUsageQueryHandler getSubscriptionUsageQueryHandler
		) : ControllerBase
	{
 	/// <summary>
        /// Gets the details of an account by its identifier.
        /// </summary>
        /// <param name="accountId">The identifier of the account.</param>
        /// <returns>An <see cref="ActionResult{AccountResource}"/> containing the account details.</returns>
		[HttpGet]
		[Route("{accountId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<AccountResource>> GetAccountDetails([FromRoute] int accountId)
		{
			var query = new GetAccountDetailsQuery(accountId);

			try
			{
				var response = await getAccountDetailsQueryHandler.Handle(query);
				if (response == null)
				{
					return NotFound();
				}
				return Ok(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting account with accountId: {accountId}", query.AccountId);
				return StatusCode(500, "Internal server error");
			}
		}
  	/// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="command">The command object containing the account details.</param>
        /// <returns>An <see cref="ActionResult{AccountResource}"/> containing the created account resource.</returns>

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<AccountResource>> CreateAccount([FromBody] CreateAccountCommand command)
		{
			try
			{
				var response = await createAccountCommandHandler.Handle(command);
				return Created("", response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating account with businessName {businessName}.", command.BusinessName);
				return StatusCode(500, "Internal server error");
			}
		}
   	 /// <summary>
        /// Updates the details of an existing account.
        /// </summary>
        /// <param name="command">The command object containing the updated account details.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<AccountResource>> UpdateAccount([FromBody] UpdateAccountCommand command)
		{
			try
			{
				await updateAccountCommandHandler.Handle(command);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating account with accountId: {AccountId}", command.AccountId);
				return StatusCode(500, "Internal server error");
			}
		}
    	 /// <summary>
        /// Deletes an account by its identifier.
        /// </summary>
        /// <param name="command">The command object containing the account identifier.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the deletion operation.</returns>

		[HttpDelete]
		[Route("{command:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> DeleteAccount([FromRoute] DeleteAccountCommand command)
		{
			try
			{
				await deleteAccountCommandHandler.Handle(command);
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while deleting account with accountId: {AccountId}", command.AccountId);
				return StatusCode(500, "Internal server error");
			}
		}
 	  /// <summary>
        /// Updates the business information for an account.
        /// </summary>
        /// <param name="accountId">The identifier of the account to update.</param>
        /// <param name="command">The command object containing the updated business information.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the update operation.</returns>

		[HttpPut]
		[Route("{accountId:int}/business")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<AccountResource>> UpdateBusinessName([FromRoute] int accountId, [FromBody] UpdateBusinessInformationCommand command)
		{
			try
			{
				if (command.AccountId != accountId)
				{
					return BadRequest();
				}
				await updateBusinessInformationCommandHandler.Handle(command);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating business information for account with accountId: {AccountId}", command.AccountId);
				return StatusCode(500, "Internal server error");
			}
		}

	/// <summary>
        /// Retrieves the subscription usage status for an account.
        /// </summary>
        /// <param name="accountId">The identifier of the account.</param>
        /// <returns>An <see cref="ActionResult{AccountUsageResource}"/> containing the subscription usage details.</returns>
		[HttpPost]
		[Route("{accountId:int}/subscription-status")]
		public async Task<ActionResult<AccountUsageResource>> GetSubscriptionStatus([FromRoute] int accountId)
		{
			try
			{
				var query = new GetSubscriptionUsageQuery(accountId);
				var response = await getSubscriptionUsageQueryHandler.Handle(query);
				return Ok(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting subscription status for account with accountId: {accountId}", accountId);
				return StatusCode(500, "Internal server error");
			}
		}

	
	}
}
