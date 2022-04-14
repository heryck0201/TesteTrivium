using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.DAO.IRepositorio;
using TesteTrivium.Data;
using TesteTrivium.Model;

namespace TesteTrivium.DAO
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Produto> Create(Produto produto)
        {
            _bancoContext.Produtos.Add(produto);
            await _bancoContext.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int Id)
        {
            var produtosDelete = await _bancoContext.Produtos.FindAsync(Id);
            _bancoContext.Produtos.Remove(produtosDelete);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _bancoContext.Produtos.ToListAsync();
        }

        public async Task<Produto> Get(int Id)
        {
            return await _bancoContext.Produtos.FindAsync(Id);
        }

        public async Task Update(Produto produto)
        {
            _bancoContext.Entry(produto).State = EntityState.Modified;
            await _bancoContext.SaveChangesAsync();
        }
    }
}
