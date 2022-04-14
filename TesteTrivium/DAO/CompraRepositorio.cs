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
    public class CompraRepositorio : ICompraRepositorio
    {
        public readonly BancoContext _bancoContext;

        public CompraRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Compra> Create(Compra compras)
        {
            _bancoContext.Compras.Add(compras);
            await _bancoContext.SaveChangesAsync();
            return compras;
        }

        public async Task Delete(int Id)
        {
            var comprasDelete = await _bancoContext.Compras.FindAsync(Id);
            _bancoContext.Compras.Remove(comprasDelete);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Compra>> Get()
        {
            return await _bancoContext.Compras.ToListAsync();
        }

        public async Task<Compra> Get(int Id)
        {
            return await _bancoContext.Compras.FindAsync(Id);
        }

        public async Task Update(Compra compra)
        {
            _bancoContext.Entry(compra).State = EntityState.Modified;
            await _bancoContext.SaveChangesAsync();
        }
    }
}
