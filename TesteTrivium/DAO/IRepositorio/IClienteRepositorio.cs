using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.Model;

namespace TesteTrivium.DAO.IRepositorio
{
   public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> Get(int id);
        Task<Cliente> Create(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
    }
}
