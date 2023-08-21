using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.API.Models
{
    public class Produtos
    {
        public int Id {get; set;}
        public string? Nome {get; set;}

        public decimal Preco {get; set;}
        
        public int Quantidade {get; set;}
    }
}