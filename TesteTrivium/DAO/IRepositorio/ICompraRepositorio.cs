using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.Model;

namespace TesteTrivium.DAO.IRepositorio
{
    public interface ICompraRepositorio
    {
        Task<IEnumerable<Compra>> Get();
        Task<Compra> Get(int Id);
        Task<Compra> Create(Compra cliente);
        Task Update(Compra cliente);
        Task Delete(int Id);
    }
}
