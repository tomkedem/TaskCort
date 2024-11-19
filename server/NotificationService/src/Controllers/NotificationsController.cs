using Microsoft.AspNetCore.Mvc;
using NotificationService.Dtos;
using NotificationService.Interfaces;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDto emailDto)
        {
            try
            {
                await _notificationService.SendEmail(emailDto);
                return Ok(new { message = "Email published to broker successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to publish email", error = ex.Message });
            }
        }
    }
}
