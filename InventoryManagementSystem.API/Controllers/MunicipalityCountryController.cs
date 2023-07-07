using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityCountryController : ControllerBase
    {
        private readonly IMunicipalityCountryService _municipalityCountryService;
        private readonly IMapper _mapper;

        public MunicipalityCountryController(IMunicipalityCountryService municipalityCountryService, IMapper mapper)
        {
            _municipalityCountryService = municipalityCountryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMunicipalitiesCountry()
        {
            var municipalitiesCountry = _municipalityCountryService.GetAllMunicipalityCountries();
            var municipalitiesCountryDto = _mapper.Map<IEnumerable<MunicipalityCountryDto>>(municipalitiesCountry);
            return Ok(municipalitiesCountryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMunicipalityCountry(int id)
        {
            var municipalityCountry = await _municipalityCountryService.GetMunicipalityCountry(id);
            var municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostMunicipalityCountry(MunicipalityCountryDto municipalityCountryDto)
        {
            var municipalityCountry = _mapper.Map<MunicipalityCountry>(municipalityCountryDto);
            await _municipalityCountryService.InsertMunicipalityCountry(municipalityCountry);
            municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMunicipalityCountry(int id, MunicipalityCountryDto municipalityCountryDto)
        {
            var municipalityCountry = _mapper.Map<MunicipalityCountry>(municipalityCountryDto);
            municipalityCountry.Id = id;
            await _municipalityCountryService.UpdateMunicipalityCountry(municipalityCountry);
            municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipalityCountry(int id)
        {
            var result = _municipalityCountryService.DeleteMunicipalityCountry(id);
            return Ok(result);
        }
    }
}
