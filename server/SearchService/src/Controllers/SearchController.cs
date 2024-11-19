using Microsoft.AspNetCore.Mvc;
using SearchService.Dtos;
using SearchService.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // API endpoint to search for cases
        [HttpPost]
        public async Task<IActionResult> SearchCases([FromBody] SearchCriteriaDto criteria)
        {
            var results = await _searchService.SearchCases(criteria);
            return Ok(results);
        }
    }
}
