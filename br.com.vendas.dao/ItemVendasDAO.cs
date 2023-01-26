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

                string sql = @"insert into tb_itensvendas (venda_id, produto_id, qtd,subtotal) 
                                    values(@venda_id, @produto_id, @qtd, @subtotal)";

                //éxecutar comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@venda_id", obj.VendaId);
                executacmd.Parameters.AddWithValue("@produto_id", obj.ProdutoId);
                executacmd.Parameters.AddWithValue("@qtd", obj.Quantidade);
                executacmd.Parameters.AddWithValue("@subtotal", obj.SubTotal);

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

        #region ListarItensVenda

        public DataTable ListarItensVenda(int idVenda)
        {
            try
            {
                //Criar o datatable e o comando sql
                DataTable tabelaItens = new DataTable();

                string sql = @"select   i.id 'codigo',
                                        p.descricao 'Descricao',
                                        i.qtd 'Quantidade',
                                        p.preco 'Preco',
                                        i.subtotal 'SubTotal'
                                        from tb_itensvendas i join
                            tb_produtos p on (i.produto_id = p.id) where venda_id = @idVenda";

                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@idVenda", idVenda);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                //Criar o MysqlDataAdapter para preencher os daodos no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaItens);

                Conexao.Close();

                return tabelaItens;

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
