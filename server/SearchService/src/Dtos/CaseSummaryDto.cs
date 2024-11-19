namespace SearchService.Dtos
{
    public class CaseSummaryDto
    {
        public int CaseId { get; set; } // Unique case identifier
        public string Title { get; set; } // Case title
        public string DateOpened { get; set; } // Case opening date (ISO 8601 format)
        public string Status { get; set; } // Case status: Active/Closed
    }
}
