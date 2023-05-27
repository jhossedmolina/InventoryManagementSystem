using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly InventoryManagerSystemDbContext _context;

        public DocumentTypeRepository(InventoryManagerSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            var documentTypes = await _context.DocumentTypes.ToListAsync();
            return documentTypes;
        }

        public async Task <DocumentType> GetDocumentType(int id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);
            return documentType;
        }

        public async Task InsertDocumentType (DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateDocumentType (DocumentType documentType)
        {
            var currentDocumentType = await GetDocumentType(documentType.Id);
            currentDocumentType.Code = documentType.Code;
            currentDocumentType.Name = documentType.Name;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteDocumentType (int id)
        {
            var currentDocumentType = await GetDocumentType(id);
            _context.DocumentTypes.Remove(currentDocumentType);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
