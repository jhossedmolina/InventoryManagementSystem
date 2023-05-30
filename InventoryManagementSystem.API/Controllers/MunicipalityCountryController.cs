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
        private readonly IMunicipalityCountryRepository _municipalityCountryRepository;
        private readonly IMapper _mapper;

        public MunicipalityCountryController(IMunicipalityCountryRepository municipalityCountryRepository, IMapper mapper)
        {
            _municipalityCountryRepository = municipalityCountryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMunicipalitiesCountry()
        {
            var municipalitiesCountry = await _municipalityCountryRepository.GetMunicipalitiesCountry();
            var municipalitiesCountryDto = _mapper.Map<IEnumerable<MunicipalityCountryDto>>(municipalitiesCountry);
            return Ok(municipalitiesCountryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMunicipalityCountry(int id)
        {
            var municipalityCountry = await _municipalityCountryRepository.GetMunicipalityCountry(id);
            var municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostMunicipalityCountry(MunicipalityCountryDto municipalityCountryDto)
        {
            var municipalityCountry = _mapper.Map<MunicipalityCountry>(municipalityCountryDto);
            await _municipalityCountryRepository.InsertMunicipalityCountry(municipalityCountry);
            municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMunicipalityCountry(int id, MunicipalityCountryDto municipalityCountryDto)
        {
            var municipalityCountry = _mapper.Map<MunicipalityCountry>(municipalityCountryDto);
            municipalityCountry.Id = id;
            await _municipalityCountryRepository.UpdateMunicipalityCountry(municipalityCountry);
            municipalityCountryDto = _mapper.Map<MunicipalityCountryDto>(municipalityCountry);
            return Ok(municipalityCountryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipalityCountry(int id)
        {
            var result = _municipalityCountryRepository.DeleteMunicipalityCountry(id);
            return Ok(result);
        }
    }
}
