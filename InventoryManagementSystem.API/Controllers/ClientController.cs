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
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = _clientService.GetAllClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            var clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostClients(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientService.InsertClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;
            await _clientService.UpdateClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteClient(id);
            return Ok(result);
        }
    }
}
