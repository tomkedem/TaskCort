namespace SearchService.Dtos
{
    public class SearchCriteriaDto
    {
        public string? Keyword { get; set; } // Search keyword in case title
        public string? Status { get; set; } // Status filter: Active/Closed/All
        public string? SortBy { get; set; } // Sort field: dateOpened or caseId
        public bool SortAscending { get; set; } // Determines if sorting is ascending
    }
}
