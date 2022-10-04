using App.API.DTO;
using App.Domain.Entities;
using App.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        [ActionName("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            var result = await _clientService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("add")]
        [ActionName("add")]
        public async Task<IActionResult> AddAsync(ClientDto data)
        {
            if (data == null)
                return BadRequest();
            data.Id = Guid.Empty;
            data.Created = DateTime.Now;
            var result = await _clientService.AddAsync(data);
            var id = result.Id;
            return Created($"{id}", id);
        }

        [HttpPut("update")]
        [ActionName("update")]
        public async Task<IActionResult> UpdateAsync(ClientDto data)
        {
            if (data == null)
                return BadRequest();
            var result = await _clientService.UpdateAsync(data, data.Id);
            if (result == null)
                return NotFound();
            return Accepted(data);
        }

        [HttpDelete("{id}")]
        [ActionName("delete")]
        public async Task<IActionResult> DeleteAync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            var result = await _clientService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
