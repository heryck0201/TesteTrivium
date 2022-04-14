using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.DAO.IRepositorio;
using TesteTrivium.Model;

namespace TesteTrivium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteRepositorio.Get();
        }

        [HttpGet("")]

        public async Task<ActionResult<Cliente>> GetClientes([FromQuery] int id)
        {
            return await _clienteRepositorio.Get(id);
        }

        [HttpPost("")]

        public async Task<ActionResult<Cliente>> PostClientes([FromBody] Cliente cliente)
        {
            var newCliente = await _clienteRepositorio.Create(cliente);

            return CreatedAtAction(nameof(GetClientes), new { id = newCliente.ID }, newCliente);
        }

        [HttpDelete("")]

        public async Task<ActionResult<Cliente>> Delete([FromQuery] int id)
        {
            var clienteDelete = await _clienteRepositorio.Get(id);

            if (clienteDelete == null)
                return NotFound();

            await _clienteRepositorio.Delete(clienteDelete.ID);
            return NoContent();
        }

        [HttpPut("")]

        public async Task<ActionResult> PutClientes(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ID)
                return BadRequest();

            await _clienteRepositorio.Update(cliente);
            return NoContent();
        }
    }
}
