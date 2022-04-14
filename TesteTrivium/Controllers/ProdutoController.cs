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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _produtoRepositorio.Get();
        }

        [HttpGet("")]

        public async Task<ActionResult<Produto>> GetProduto([FromQuery] int id)
        {
            return await _produtoRepositorio.Get(id);
        }

        [HttpPost("")]

        public async Task<ActionResult<Produto>> PostGetProdutoDelete([FromBody] Produto produto)
        {
            var newProduto = await _produtoRepositorio.Create(produto);

            return CreatedAtAction(nameof(PostGetProdutoDelete), new { id = newProduto.ID }, newProduto);
        }

        [HttpDelete("")]

        public async Task<ActionResult<Produto>> Delete([FromQuery] int id)
        {
            var produtoDelete = await _produtoRepositorio.Get(id);

            if (produtoDelete == null)
                return NotFound();

            await _produtoRepositorio.Delete(produtoDelete.ID);
            return NoContent();
        }

        [HttpPut("")]

        public async Task<ActionResult> PutClientes(int id, [FromBody] Produto produto)
        {
            if (id != produto.ID)
                return BadRequest();

            await _produtoRepositorio.Update(produto);
            return NoContent();
        }
    }
}
