using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IDocumentTypeService
    {
        IEnumerable<DocumentType> GetDocumentTypes();
        Task<DocumentType> GetDocumentType(int id);
        Task InsertDocumentType(DocumentType documentType);
        Task<bool> UpdateDocumentType(DocumentType documentType);
        Task<bool> DeleteDocumentType(int id);
    }
}
