using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Core.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DocumentType> GetDocumentTypes()
        {
            return _unitOfWork.DocumentTypeRepository.GetAll();
        }

        public async Task<DocumentType> GetDocumentType(int id)
        {
            return await _unitOfWork.DocumentTypeRepository.GetById(id);
        }

        public async Task InsertDocumentType(DocumentType documentType)
        {
            await _unitOfWork.DocumentTypeRepository.Add(documentType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateDocumentType(DocumentType documentType)
        {
            var currentDocumentType = await _unitOfWork.DocumentTypeRepository.GetById(documentType.Id);
            currentDocumentType.Code = documentType.Code;
            currentDocumentType.Name = documentType.Name;
            _unitOfWork.DocumentTypeRepository.Update(currentDocumentType);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            await _unitOfWork.DocumentTypeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
