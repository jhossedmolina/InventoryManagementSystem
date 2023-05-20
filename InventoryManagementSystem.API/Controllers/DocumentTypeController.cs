using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentTypes()
        {
            var documentTypes = await _documentTypeRepository.GetDocumentTypes();
            var documentTypesDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
            return Ok(documentTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentType(int id)
        {
            var documentType = await _documentTypeRepository.GetDocumentType(id);
            var documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PosDocumentType(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeRepository.InsertDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType(int id, DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            documentType.Id = id;
            await _documentTypeRepository.UpdateDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteDocumentType(int id)
        {
            var result = await _documentTypeRepository.DeleteDocumentType(id);
            return Ok(result);
        }
    }
}
