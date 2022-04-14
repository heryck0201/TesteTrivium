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
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepositorio _compraRepositorio;

        public CompraController(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Compra>> Get()
        {
            return await _compraRepositorio.Get();
        }

        [HttpGet("")]

        public async Task<ActionResult<Compra>> GetCompras([FromQuery] int id)
        {
            return await _compraRepositorio.Get(id);
        }

        [HttpPost("")]

        public async Task<ActionResult<Compra>> PostCompras([FromBody] Compra compra)
        {
            var newCompra = await _compraRepositorio.Create(compra);

            return CreatedAtAction(nameof(GetCompras), new { id = newCompra.ID }, newCompra);
        }

        [HttpDelete("")]

        public async Task<ActionResult<Compra>> Delete([FromQuery] int id)
        {
            var compraDelete = await _compraRepositorio.Get(id);

            if (compraDelete == null)
                return NotFound();

            await _compraRepositorio.Delete(compraDelete.ID);
            return NoContent();
        }

        [HttpPut("")]

        public async Task<ActionResult> PutClientes(int id, [FromBody] Compra compra)
        {
            if (id != compra.ID)
                return BadRequest();

            await _compraRepositorio.Update(compra);
            return NoContent();
        }
    }
}
