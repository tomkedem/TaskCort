using SearchService.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchService.Interfaces
{
    public interface ISearchService
    {
        // Searches for cases based on the provided criteria
        Task<List<CaseSummaryDto>> SearchCases(SearchCriteriaDto criteria);
    }
}
