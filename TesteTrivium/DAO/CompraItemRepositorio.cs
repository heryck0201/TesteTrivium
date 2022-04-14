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
    public class CompraItemRepositorio : ICompraItemRepositorio
    {
        public readonly BancoContext _bancoContext;
        public CompraItemRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<CompraItem> Create(CompraItem compraItem)
        {
            _bancoContext.CompraItens.Add(compraItem);
            await _bancoContext.SaveChangesAsync();
            return compraItem;
        }

        public async Task Delete(int Id)
        {
            var produtosDelete = await _bancoContext.CompraItens.FindAsync(Id);
            _bancoContext.CompraItens.Remove(produtosDelete);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompraItem>> Get()
        {
            return await _bancoContext.CompraItens.ToListAsync();
        }

        public async Task<CompraItem> Get(int Id)
        {
            return await _bancoContext.CompraItens.FindAsync(Id);
        }

        public async Task Update(CompraItem compraItem)
        {
            _bancoContext.Entry(compraItem).State = EntityState.Modified;
            await _bancoContext.SaveChangesAsync();
        }
    }
}
