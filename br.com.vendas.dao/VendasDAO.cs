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
    public class VendasDAO
    {
        private MySqlConnection Conexao;
        public VendasDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }

        #region CadastrarVenda
        public void CadastrarVenda(Venda obj)
        {
            try
            {
                string sql = @"insert into tb_vendas (cliente_id, data_venda, total_venda, observacoes) 
                                    values(@cliente_id, @data_venda, @total_venda, @obs)";

                //éxecutar comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@cliente_id", obj.ClienteId);
                executacmd.Parameters.AddWithValue("@data_venda", obj.DataVenda);
                executacmd.Parameters.AddWithValue("@total_venda", obj.TotalVendas);
                executacmd.Parameters.AddWithValue("@obs", obj.Obs);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Venda cadastrado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro);
            }
        }

        #endregion

        #region RetornarIdUltimaVenda

        public int RetornarIdUltimaVenda()
        {
            try
            {
                int idVenda = 0;
                String sql = "select  mas(id) id from  tb_vendas;";
                MySqlCommand executacmdsql = new MySqlCommand(sql, Conexao);    

                MySqlDataReader rs = executacmdsql.ExecuteReader();

                if (rs.Read())
                {
                    Venda obj = new Venda();
                    obj.Id = rs.GetInt32("id");
                    idVenda = obj.Id;
                }
                Conexao.Close();
                return  idVenda;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao retornar: " + erro);
                return 0;
            }
        }

        #endregion
    }
}
