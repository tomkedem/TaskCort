using NotificationService.Dtos;

namespace NotificationService.Interfaces
{
    public interface INotificationService
    {
        Task SendEmail(EmailDto emailDto); // Publish email to broker
    }
}
