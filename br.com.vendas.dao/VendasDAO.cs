using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Collections.Generic;
using System.Data;
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
                String sql = "select max(id) id from tb_vendas;";      
                MySqlCommand executacmdsql = new MySqlCommand(sql, Conexao);

                Conexao.Open();
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

        #region ExibirHistoricoVenda

        public DataTable ExibirHistoricoVenda(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                //Criar o datatable e o comando sql
                DataTable  tabelaHistorico = new DataTable();

                string sql = @"select v.id 'Código',
	                                  v.data_venda  'Data da Venda',
	                                  c.nome 'Cliente',
	                                  v.total_venda 'Total',
	                                  v.observacoes 'Observação'
                             from tb_vendas v join tb_clientes c  on (v.cliente_id = c.id)
                             where v.data_venda between @datainicio and @datafim";

                // Organizar e executar comando sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, Conexao);
                executacmdsql.Parameters.AddWithValue("@datainicio", dataInicio);
                executacmdsql.Parameters.AddWithValue("@datafim", dataFim);

                Conexao.Open();
                executacmdsql.ExecuteNonQuery();

                //Criar o MysqlDataAdapter para preencher os daodos no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);  
                da.Fill(tabelaHistorico);

                Conexao.Close();

                return tabelaHistorico;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro);
                return null;
            }
        }


        #endregion

        #region ListarVendas

        public DataTable ListarVendas()
        {
            try
            {
                //Criar o datatable e o comando sql
                DataTable tabelaHistorico = new DataTable();

                string sql = @"select v.id 'Codigo',
	                                  v.data_venda  'Data da Venda',
	                                  c.nome 'Cliente',
	                                  v.total_venda 'Total',
	                                  v.observacoes 'Observacao'
                             from tb_vendas v join tb_clientes c  on (v.cliente_id = c.id)";

                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MysqlDataAdapter para preencher os daodos no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaHistorico);

                Conexao.Close();

                return tabelaHistorico;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro" + erro);
                return null;
            }
        }

        #endregion
    }
}
