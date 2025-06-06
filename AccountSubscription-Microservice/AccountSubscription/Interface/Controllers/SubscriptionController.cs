using DittoBox.API.AccountSubscription.Application.Commands;
using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.AccountSubscription.Interface.Controllers
{
	/// <summary>
   	 /// Controller for managing subscriptions.
   	 /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubscriptionController(
        ILogger<SubscriptionController> logger,
        IGetSubscriptionDetailsQueryHandler getSubscriptionDetailsQueryHandler,
        IUpgradeSubscriptionCommandHandler upgradeSubscriptionCommandHandler,
        IDowngradeSubscriptionCommandHandler downgradeSubscriptionCommandHandler,
        ICancelSubscriptionCommandHandler cancelSubscriptionCommandHandler
        ) : ControllerBase
    {
     /// <summary>
        /// Retrieves the details of a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to retrieve.</param>
        /// <returns>The details of the subscription.</returns>
        /// <response code="200">Returns the subscription details.</response>
        /// <response code="403">If the user is not authorized to access the subscription.</response>
        /// <response code="404">If the subscription is not found.</response>
        [HttpGet]
        [Route("{subscriptionId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResource>> GetSubscriptionDetails([FromRoute]int subscriptionId)
        {
			var query = new GetSubscriptionDetailsQuery(subscriptionId);
            try
            {
                var response = await getSubscriptionDetailsQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting subscription details for subscription {query.SubscriptionId}", query.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

	/// <summary>
        /// Upgrades an existing subscription.
        /// </summary>
        /// <param name="command">The command containing subscription upgrade details.</param>
        /// <returns>No content on successful upgrade.</returns>
        /// <response code="200">Indicates that the subscription was upgraded successfully.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="403">If the user is not authorized to upgrade the subscription.</response>
        /// <response code="404">If the subscription is not found.</response>
        [HttpPost]
        [Route("upgrade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResource))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResource>> UpgradeSubscription([FromBody] UpgradeSubscriptionCommand command)
        {
            try
            {
                await upgradeSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Upgraded subscription {command.SubscriptionId}", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error upgrading subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
	/// <summary>
        /// Downgrades an existing subscription.
        /// </summary>
        /// <param name="command">The command containing subscription downgrade details.</param>
        /// <returns>No content on successful downgrade.</returns>
        /// <response code="200">Indicates that the subscription was downgraded successfully.</response>

        [HttpPost]
        [Route("downgrade")]
        public async Task<IActionResult> DowngradeSubscription([FromBody] DowngradeSubscriptionCommand command)
        {
            try
            {
                await downgradeSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Downgraded subscription {command.SubscriptionId}", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error downgrading subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
	/// <summary>
        /// Cancels an existing subscription.
        /// </summary>
        /// <param name="command">The command containing subscription cancellation details.</param>
        /// <returns>No content on successful cancellation.</returns>
        /// <response code="200">Indicates that the subscription was cancelled successfully.</response>

        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelSubscription([FromBody] CancelSubscriptionCommand command)
        {
            try
            {
                await cancelSubscriptionCommandHandler.Handle(command);
                logger.LogInformation("Subscription {command.SubscriptionId} cancelled", command.SubscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error cancelling subscription {command.SubscriptionId}", command.SubscriptionId);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
