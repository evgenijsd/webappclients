using App.API.DTO;
using App.Domain.Entities;
using App.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IGenericService<Client, ClientDto> _clientService;

        public ClientController(IGenericService<Client, ClientDto> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("all")]
        [ActionName("all")]
        public async Task<IActionResult> Get()
        {
            var result = await _clientService.GetAllAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
