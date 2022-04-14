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
    public class CompraItemController : ControllerBase
    {
        private readonly ICompraItemRepositorio _compraItemRepositorio;

        public CompraItemController(ICompraItemRepositorio compraItemRepositorio)
        {
            _compraItemRepositorio = compraItemRepositorio;
        }

        [HttpGet("")]
        public async Task<IEnumerable<CompraItem>> Get()
        {
            return await _compraItemRepositorio.Get();
        }

        [HttpGet("")]

        public async Task<ActionResult<CompraItem>> GetCompraItem([FromQuery] int id)
        {
            return await _compraItemRepositorio.Get(id);
        }

        [HttpPost("")]

        public async Task<ActionResult<CompraItem>> PostCompraItem([FromBody] CompraItem compra)
        {
            var newCliente = await _compraItemRepositorio.Create(compra);

            return CreatedAtAction(nameof(GetCompraItem), new { id = newCliente.ID }, newCliente);
        }

        [HttpDelete("")]

        public async Task<ActionResult<CompraItem>> Delete([FromQuery] int id)
        {
            var compraDelete = await _compraItemRepositorio.Get(id);

            if (compraDelete == null)
                return NotFound();

            await _compraItemRepositorio.Delete(compraDelete.ID);
            return NoContent();
        }

        [HttpPut("")]

        public async Task<ActionResult> PutClientes(int id, [FromBody] CompraItem compraItem)
        {
            if (id != compraItem.ID)
                return BadRequest();

            await _compraItemRepositorio.Update(compraItem);
            return NoContent();
        }
    }
}
