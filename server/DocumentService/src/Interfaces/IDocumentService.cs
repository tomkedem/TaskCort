using DocumentService.Dtos;

namespace DocumentService.Interfaces
{
    public interface IDocumentService
    {
        // Upload a new document
        Task<bool> UploadDocument(UploadDocumentDto documentDto);

        // Get details of a document by ID
        Task<DocumentDetailsDto?> GetDocumentDetails(int documentId);

        // Update a document by ID
        Task<bool> UpdateDocument(int documentId, UpdateDocumentDto updateDto);

        // Delete a document by ID
        Task<bool> DeleteDocument(int documentId);

        // Retrieve all documents
        Task<List<DocumentDetailsDto>> GetDocuments();
    }
}
