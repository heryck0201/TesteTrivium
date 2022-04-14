using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteTrivium.Model
{
    public class CompraItem
    {
        public int ID { get; set; }
        public int IDCompra { get; set; }
        public int IDProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
