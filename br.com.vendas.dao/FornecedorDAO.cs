

using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.dao
{
    public class FornecedorDAO
    {
        private MySqlConnection Conexao;

        public FornecedorDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }
      
        #region CadastrarFornecedor
        public void CadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                //  definir o cmd sql  - insert into
                string sql = @"insert into tb_fornecedores (nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                             values (@nome,@cnpj,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado) ";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);               
                executacmd.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);

                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        
        #region AlterarFornecedor
        public void AlterarFornecedor(Fornecedor obj)
        {
            try
            {
                //  definir o cmd sql  - Update
                string sql = @"update tb_fornecedores set nome=@nome,cnpj=@cnpj,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                            endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                            where id=@id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);

                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        
        #region ExcluirFornecedor
        public void ExcluirFornecedor(Fornecedor obj)
        {
            try
            {
                //  definir o cmd sql  - delete
                string sql = @"delete from tb_fornecedores where id = @id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);


                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Excluido com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                
            }
        }

        
        #endregion
       
        #region ListarFornecedor

        public DataTable ListarFornecedor()
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                //Fechar a conexao
                Conexao.Close();
                return tabelaFornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion
        

        #region BuscarFornecedorPorNome

        public DataTable BuscarFornecedorPorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome=@nome";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                //Fechar a conexao
                Conexao.Close();

                return tabelaFornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;

            }

        }

        #endregion
         

        #region ListarFornecedorPorNome

        public DataTable ListarFornecedorPorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome like @nome"; // like pesquisa por aproximação

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                //Fechar a conexao
                Conexao.Close();

                return tabelaFornecedor;

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
