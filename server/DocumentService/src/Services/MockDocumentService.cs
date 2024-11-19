using DocumentService.Dtos;
using DocumentService.Interfaces;

namespace DocumentService.Services
{
    public class MockDocumentService : IDocumentService
    {
        // Simulated list of documents
        private readonly List<DocumentDetailsDto> _documents = new List<DocumentDetailsDto>
        {
            new DocumentDetailsDto { Id = 1, Title = "Document A", Content = "Content of Document A", CreatedDate = DateTime.UtcNow },
            new DocumentDetailsDto { Id = 2, Title = "Document B", Content = "Content of Document B", CreatedDate = DateTime.UtcNow },
        };

        public Task<bool> UploadDocument(UploadDocumentDto documentDto)
        {
            var newDocument = new DocumentDetailsDto
            {
                Id = _documents.Max(d => d.Id) + 1,
                Title = documentDto.Title,
                Content = documentDto.Content,
                CreatedDate = DateTime.UtcNow
            };
            _documents.Add(newDocument);
            return Task.FromResult(true);
        }

        public Task<DocumentDetailsDto?> GetDocumentDetails(int documentId)
        {
            var document = _documents.FirstOrDefault(d => d.Id == documentId);
            return Task.FromResult(document);
        }

        public Task<bool> UpdateDocument(int documentId, UpdateDocumentDto updateDto)
        {
            var document = _documents.FirstOrDefault(d => d.Id == documentId);
            if (document != null)
            {
                document.Title = updateDto.Title;
                document.Content = updateDto.Content;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> DeleteDocument(int documentId)
        {
            var document = _documents.FirstOrDefault(d => d.Id == documentId);
            if (document != null)
            {
                _documents.Remove(document);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<DocumentDetailsDto>> GetDocuments()
        {
            return Task.FromResult(_documents);
        }
    }
}
