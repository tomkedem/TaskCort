using CaseManagementService.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagementService.Interfaces
{
    public interface ICaseService
    {
        // Creates a new case
        Task<bool> CreateCase(CreateCaseDto caseDto);

        // Retrieves details of a single case by its ID
        Task<CaseDetailsDto?> GetCaseDetails(int caseId);

        // Updates a case
        Task<bool> UpdateCase(int caseId, UpdateCaseDto updateCaseDto);

        // Retrieves all cases
        Task<List<CaseDetailsDto>> GetCases();
    }
}
