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
    public class ClienteRepositorio : IClienteRepositorio
    {
        public readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Cliente> Create(Cliente cliente)
        {
            _bancoContext.Clientess.Add(cliente);
            await _bancoContext.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var clenteDelete = await _bancoContext.Clientess.FindAsync(id);
            _bancoContext.Clientess.Remove(clenteDelete);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _bancoContext.Clientess.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _bancoContext.Clientess.FindAsync(id);
        }

        public async Task Update(Cliente cliente)
        {
            _bancoContext.Entry(cliente).State = EntityState.Modified;
            await _bancoContext.SaveChangesAsync();
        }
    }
}
