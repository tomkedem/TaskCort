using SearchService.Dtos;
using SearchService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchService.Services
{
    public class MockSearchService : ISearchService
    {
        // Hardcoded list of cases for simulation
        private readonly List<CaseSummaryDto> _cases = new List<CaseSummaryDto>
        {
            new CaseSummaryDto { CaseId = 108, Title = "Eligibility Check Decision 3", DateOpened = "2024-07-15", Status = "Active" },
            new CaseSummaryDto { CaseId = 107, Title = "Sample Case Example", DateOpened = "2024-07-14", Status = "Closed" },
            new CaseSummaryDto { CaseId = 106, Title = "Legal Review", DateOpened = "2024-06-20", Status = "Active" },
            new CaseSummaryDto { CaseId = 105, Title = "Legal Case Closure", DateOpened = "2023-12-01", Status = "Closed" },
        };

        // Implements the search functionality
        public Task<List<CaseSummaryDto>> SearchCases(SearchCriteriaDto criteria)
        {
            var query = _cases.AsQueryable();

            // Filter by keyword
            if (!string.IsNullOrEmpty(criteria.Keyword))
            {
                query = query.Where(c => c.Title.Contains(criteria.Keyword, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by status
            if (!string.IsNullOrEmpty(criteria.Status) && criteria.Status != "All")
            {
                query = query.Where(c => c.Status.Equals(criteria.Status, StringComparison.OrdinalIgnoreCase));
            }

            // Sort by the specified field
            if (!string.IsNullOrEmpty(criteria.SortBy))
            {
                query = criteria.SortBy switch
                {
                    "caseId" => criteria.SortAscending
                        ? query.OrderBy(c => c.CaseId)
                        : query.OrderByDescending(c => c.CaseId),
                    "dateOpened" => criteria.SortAscending
                        ? query.OrderBy(c => DateTime.Parse(c.DateOpened))
                        : query.OrderByDescending(c => DateTime.Parse(c.DateOpened)),
                    _ => query
                };
            }

            // Return the filtered and sorted results
            return Task.FromResult(query.ToList());
        }

    }
}
