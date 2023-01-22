using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendas.br.com.vendas.model
{
    public class Venda
    {
        //Atributos e Propiendades de acesso 
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public int TotalVendas { get; set; }
        public string Obs { get; set; }
    }
}
