using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationApi.Repository;

namespace NotificationApi.Controllers
{
    [Route("api/novu")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NovuService _novuService;

        public NotificationsController(NovuService novuService)
        {
            _novuService = novuService;
        }

        // Endpoint to trigger the Novu event
        [HttpPost("send-welcome-email")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] SubscriberInfo subscriber)
        {
            if (subscriber == null || string.IsNullOrEmpty(subscriber.Email))
            {
                return BadRequest("Invalid subscriber data.");
            }

            // Call NovuService to trigger the event
            await _novuService.TriggerEventAsync(subscriber.SubscriberId, subscriber.Email, subscriber.phone);

            return Ok("Event triggered successfully.");
        }
    }

    public class SubscriberInfo
    {
        public string SubscriberId { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
    }

}
