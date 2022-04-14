using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.Model;

namespace TesteTrivium.DAO.IRepositorio
{
   public interface ICompraItemRepositorio
    {
        Task<IEnumerable<CompraItem>> Get();
        Task<CompraItem> Get(int Id);
        Task<CompraItem> Create(CompraItem cliente);
        Task Update(CompraItem cliente);
        Task Delete(int Id);
    }
}
