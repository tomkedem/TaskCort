using Microsoft.AspNetCore.Mvc;
using CaseManagementService.Dtos;
using CaseManagementService.Interfaces;

namespace CaseManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ICaseService _caseService;

        public CasesController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] CreateCaseDto caseDto)
        {
            var result = await _caseService.CreateCase(caseDto);
            return Ok(new { success = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseDetails(int id)
        {
            var result = await _caseService.GetCaseDetails(id);
            if (result == null)
            {
                return NotFound(new { message = "Case not found" });
            }
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCase(int id, [FromBody] UpdateCaseDto updateCaseDto)
        {
            var result = await _caseService.UpdateCase(id, updateCaseDto);
            return Ok(new { success = result });
        }
    }
}
