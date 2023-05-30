using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientRepository.GetClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientRepository.GetClient(id);
            var clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostClients(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.InsertClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;
            await _clientRepository.UpdateClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientRepository.DeleteClient(id);
            return Ok(result);
        }
    }
}
