using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTrivium.Model;

namespace TesteTrivium.DAO.IRepositorio
{
  public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> Get();
        Task<Produto> Get(int Id);
        Task<Produto> Create(Produto cliente);
        Task Update(Produto cliente);
        Task Delete(int Id);
    }
}
