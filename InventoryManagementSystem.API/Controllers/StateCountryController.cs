using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateCountryController : ControllerBase
    {
        private readonly IStateCountryService _stateCountryService;
        private readonly IMapper _mapper;

        public StateCountryController(IStateCountryService stateCountryService, IMapper mapper)
        {
            _stateCountryService = stateCountryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStateCountries()
        {
            var stateCountries = _stateCountryService.GetAllStateCountries();
            var stateCountriesDto = _mapper.Map<StateCountryDto>(stateCountries);
            return Ok(stateCountriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateCountry(int id)
        {
            var stateCountry = await _stateCountryService.GetStateCountry(id);
            var stateCountryDto = _mapper.Map<StateCountryDto>(stateCountry);
            return Ok(stateCountryDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostStateCountry(StateCountryDto stateCountryDto)
        {
            var stateCountry = _mapper.Map<StateCountry>(stateCountryDto);
            await _stateCountryService.InsertStateCountry(stateCountry);
            stateCountryDto = _mapper.Map<StateCountryDto>(stateCountry);
            return Ok(stateCountryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateCountry(int id, StateCountryDto stateCountryDto)
        {
            var stateCountry = _mapper.Map<StateCountry>(stateCountryDto);
            await _stateCountryService.UpdateStateCountry(stateCountry);
            stateCountryDto = _mapper.Map<StateCountryDto>(stateCountry);
            return Ok(stateCountryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateCountry(int id)
        {
            var result = await _stateCountryService.DeleteStateCountry(id);
            return Ok(result);
        }
    }
}
