using Microsoft.AspNetCore.Mvc;
using DocumentService.Dtos;
using DocumentService.Interfaces;

namespace DocumentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromBody] UploadDocumentDto documentDto)
        {
            var result = await _documentService.UploadDocument(documentDto);
            return Ok(new { success = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentDetails(int id)
        {
            var document = await _documentService.GetDocumentDetails(id);
            if (document == null)
            {
                return NotFound(new { message = "Document not found" });
            }
            return Ok(document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] UpdateDocumentDto updateDto)
        {
            var result = await _documentService.UpdateDocument(id, updateDto);
            if (!result)
            {
                return NotFound(new { message = "Document not found for update" });
            }
            return Ok(new { success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var result = await _documentService.DeleteDocument(id);
            if (!result)
            {
                return NotFound(new { message = "Document not found for deletion" });
            }
            return Ok(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _documentService.GetDocuments();
            return Ok(documents);
        }
    }
}
