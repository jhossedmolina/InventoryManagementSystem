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
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public DocumentTypeController(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentTypes()
        {
            var documentTypes = _documentTypeService.GetDocumentTypes();
            var documentTypesDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
            return Ok(documentTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentType(int id)
        {
            var documentType = await _documentTypeService.GetDocumentType(id);
            var documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PosDocumentType(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeService.InsertDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType(int id, DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            documentType.Id = id;
            await _documentTypeService.UpdateDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteDocumentType(int id)
        {
            var result = await _documentTypeService.DeleteDocumentType(id);
            return Ok(result);
        }
    }
}
