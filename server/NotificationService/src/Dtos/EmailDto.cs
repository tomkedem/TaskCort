namespace NotificationService.Dtos
{
    public class EmailDto
    {
        public string Recipient { get; set; } // Example: user@example.com
        public string Subject { get; set; }   // Example: "Welcome"
        public string Body { get; set; }      // Example: "Thank you for signing up!"
    }
}
