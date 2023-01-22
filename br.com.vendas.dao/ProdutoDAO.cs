using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.dao
{
    internal class ProdutoDAO
    {
        private MySqlConnection Conexao;
        public ProdutoDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }
        #region CadastrarProduto
        public void cadastrarProduto(Produtos obj)
        {
            try
            {
                //  definir o cmd sql  - insert into
                string sql = @"insert into tb_produtos(descricao, preco, qtd_estoque, for_id) values (@descricao, @preco, @qtd_estoque, @for_id)";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.Preco);
                executacmd.Parameters.AddWithValue("@qtd_estoque", obj.QuantidadeEstoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.For_id);


                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region ListarProduto

        public DataTable ListarProduto()
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaProduto = new DataTable();
                string sql = @"select p.id 'Codigo', 
                                       p.descricao 'Descricao',
                                       p.preco 'Preco', 
                                       p.qtd_estoque 'Quantida estoque', 
                                       f.nome 'Fornecedor' from tb_produtos p
                                       join tb_fornecedores f on (p.for_id = f.id); ";



                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                //Fechar a conexao
                Conexao.Close();
                return tabelaProduto;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region AlterarProduto
        public void AlterarProduto(Produtos obj)
        {
            try
            {
                //  definir o cmd sql  - Update
                string sql = @"update tb_produtos set descricao=@descricao, preco=@preco, qtd_estoque=@qtd_estoque, for_id=for_id
                            where id=@id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.Preco);
                executacmd.Parameters.AddWithValue("@qtd_estoque", obj.QuantidadeEstoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.For_id);
                executacmd.Parameters.AddWithValue("@id", obj.Id);


                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto Alterado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }
        #endregion

        #region ExcluirProduto
        public void ExcluirProduto(Produtos obj)
        {
            try
            {
                //  definir o cmd sql  - Update
                string sql = @"delete from  tb_produtos  where id=@id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@id", obj.Id);


                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto Alterado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
            #endregion

        #region ListarProdutosPorNome

            public DataTable ListarProdutosPorNome(string nome)
            {
                try
                {   // DateTable com e o comando sql
                    DataTable tabelaProduto = new DataTable();
                    string sql = @"select p.id 'Codigo', 
                                       p.descricao 'Descricao',
                                       p.preco 'Preco', 
                                       p.qtd_estoque 'Quantida estoque', 
                                       f.nome 'Fornecedor' from tb_produtos p
                                       join tb_fornecedores f on (p.for_id = f.id) where p.descricao like @nome; ";



                    //  Organizar o comando sql e executar
                    MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                    executacmd.Parameters.AddWithValue("@nome", nome);

                    Conexao.Open();
                    executacmd.ExecuteNonQuery();

                    // Criar o MySQLDataApter para preencher  os dados no DataTable
                    MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                    da.Fill(tabelaProduto);

                    //Fechar a conexao
                    Conexao.Close();
                    return tabelaProduto;

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao executar o comando sql: " + erro);
                    return null;
                }

            }
        #endregion

        #region BuscarProdutosPorNome

        public DataTable BuscarProdutosPorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaProduto = new DataTable();
                string sql = @"select p.id 'Codigo', 
                                       p.descricao 'Descricao',
                                       p.preco 'Preco', 
                                       p.qtd_estoque 'Quantida estoque', 
                                       f.nome 'Fornecedor' from tb_produtos p
                                       join tb_fornecedores f on (p.for_id = f.id) where p.descricao = @nome; ";



                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                //Fechar a conexao
                Conexao.Close();
                return tabelaProduto;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }
        #endregion


        #region RetornarProdutoPorCodigo
        public Produtos RetonarProdutoPorCodigo(int id)
        {
            try
            {
                // Criar o comando sql e o objeto Cliente
                Produtos obj = new Produtos();
                string sql = @"select  * from tb_produtos where id = @id";

                //Organizar  o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@id", id);

                Conexao.Open();

                //criar o MySqlDataReader
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.Id = rs.GetInt32("id");
                    obj.Descricao = rs.GetString("descricao");
                    obj.Preco = rs.GetDecimal("preco");

                    Conexao.Close();
                    return obj;
                }
                else
                {
                    MessageBox.Show("Produto não encontrato");
                    Conexao.Close();
                    return null;
                }
                return obj;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }
        }

        #endregion
    }
}