using CaseManagementService.Dtos;
using CaseManagementService.Interfaces;

namespace CaseManagementService.Services
{
    public class MockCaseService : ICaseService
    {
        // Simulated list of cases
        private readonly List<CaseDetailsDto> _cases = new List<CaseDetailsDto>
        {
            new CaseDetailsDto { Id = 1, Title = "Case A", Status = "Open" },
            new CaseDetailsDto { Id = 2, Title = "Case B", Status = "Closed" },
            new CaseDetailsDto { Id = 3, Title = "Case C", Status = "In Progress" }
        };

        // Simulate creating a case
        public Task<bool> CreateCase(CreateCaseDto caseDto)
        {
            // Add the new case to the list
            var newCase = new CaseDetailsDto
            {
                Id = _cases.Max(c => c.Id) + 1, // Generate new ID
                Title = caseDto.Title,
                Status = "New"
            };
            _cases.Add(newCase);

            // Notify relevant parties via NotificationService
            try
            {
                await NotifyAboutNewCase(newCase);
                Console.WriteLine("Notification sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send notification: {ex.Message}");
                // Handle failure: logging, retry logic, etc.
            }

            return Task.FromResult(true);
        }

        // Method to call NotificationService
        private async Task NotifyAboutNewCase(CaseDetailsDto newCase)
        {
            // Assuming you use HttpClient to communicate with the notification microservice
            var notificationPayload = new
            {
                To = "relevant@party.com",
                Subject = $"New Case Created: {newCase.Title}",
                Body = $"A new case with ID {newCase.Id} has been created with status '{newCase.Status}'."
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(notificationPayload),
                Encoding.UTF8,
                "application/json"
            );

            using var client = new HttpClient();
            try
            {
                var response = await client.PostAsync("https://notification-service/api/notifications/send-email", jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while sending notification", ex);
            }
        }

        // Simulate retrieving case details
        public Task<CaseDetailsDto?> GetCaseDetails(int caseId)
        {
            var caseDetails = _cases.FirstOrDefault(c => c.Id == caseId);
            return Task.FromResult(caseDetails);
        }


        // Simulate updating a case
        public Task<bool> UpdateCase(int caseId, UpdateCaseDto updateCaseDto)
        {
            var caseToUpdate = _cases.FirstOrDefault(c => c.Id == caseId);
            if (caseToUpdate != null)
            {
                caseToUpdate.Title = updateCaseDto.Title;
                caseToUpdate.Status = updateCaseDto.Status;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        // Simulate retrieving all cases
        public Task<List<CaseDetailsDto>> GetCases()
        {
            return Task.FromResult(_cases);
        }
    }
}
