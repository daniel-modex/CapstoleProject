using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationApi.model;
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
        public async Task<IActionResult> SendWelcomeEmail(Details details)
        {
            if (details == null || string.IsNullOrEmpty(details.email))
            {
                return BadRequest("Invalid subscriber data.");
            }

            // Call NovuService to trigger the event
            await _novuService.TriggerEventAsync(details);

            return Ok("Event triggered successfully.");
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOTP(Details details)
        {
            if (string.IsNullOrEmpty(details.email))
            {
                return BadRequest("Invalid subscriber data.");
            }

            // Call NovuService to trigger the event
            await _novuService.TriggerEventOTPAsync(details);

            return Ok("Event triggered successfully.");
        }
    }

    

}
