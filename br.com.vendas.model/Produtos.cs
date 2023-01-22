using System;


namespace ProjetoVendas.br.com.vendas.model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int  QuantidadeEstoque { get; set; }
        public int For_id { get; set; }
    }
}
