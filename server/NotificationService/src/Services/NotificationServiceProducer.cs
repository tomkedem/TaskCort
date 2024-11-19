using System.Text;
using System.Text.Json;
using NotificationService.Dtos;
using NotificationService.Interfaces;
using RabbitMQ.Client;

namespace NotificationService.Services
{
    public class NotificationServiceProducer : INotificationService
    {
        private readonly string _brokerHostname = "localhost"; // Change if necessary
        private readonly string _queueName = "email_queue";

        public Task SendEmail(EmailDto emailDto)
        {
            // Serialize the email DTO
            var emailPayload = JsonSerializer.Serialize(emailDto);
            var body = Encoding.UTF8.GetBytes(emailPayload);

            // Connect to RabbitMQ
            var factory = new ConnectionFactory() { HostName = _brokerHostname };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the queue
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            // Publish the message to the queue
            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[x] Email published to broker: {emailPayload}");

            return Task.CompletedTask;
        }
    }
}
