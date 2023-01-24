using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.dao
{
    public class ItemVendasDAO
    {
        private MySqlConnection Conexao;
        public ItemVendasDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }

        #region CadastarItemVenda
            
        public void CadastarItemVenda(ItemVendas  obj)
        {
            try
            {

                string sql = @"insert into tb_itensvendas (vendas_id, produto_id, qtd,subtotal) 
                                    values(@vendas_id, @produto_id, @qtd, @subtotal)";

                //éxecutar comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@vendas_id", obj.VendaId);
                executacmd.Parameters.AddWithValue("@produto_id", obj.ProdutoId);
                executacmd.Parameters.AddWithValue("@qtd", obj.Quantidade);
                executacmd.Parameters.AddWithValue("@subtotal", obj.SubTotal);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Item  cadastrado com sucesso!");

                //Fechar a conexao
                Conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro);
            }
        }

        #endregion
    }
}
