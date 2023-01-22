using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.dao
{
    public class ClienteDAO
    {
        private MySqlConnection Conexao;
        public ClienteDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }
        #region CadastrarCliente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                //  definir o cmd sql  - insert into
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                             values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado) ";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
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

        #region AlterarCliente
        public void AlterarCliente(Cliente obj)
        {
            try
            {
                //  definir o cmd sql  - Update
                string sql =@"update tb_clientes (nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                            endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado)
                            where id=@id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
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

                MessageBox.Show("Cliente Alterado com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ExcluirCliente
        public void ExcluirCliente(Cliente obj)
        {
            try
            {
                //  definir o cmd sql  - delete
                string sql = @"delete from tb_clientes where id = @id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);


                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Excluido com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region ListarCliente

        public DataTable ListarCliente(){
            try
            {   // DateTable com e o comando sql
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                //Fechar a conexao
                Conexao.Close();
                return tabelaCliente;               

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: "  + erro);
                return null;
            }
            
        }

        #endregion

        #region BuscarClientePorNome

        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes where nome=@nome";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                //Fechar a conexao
                Conexao.Close();

                return tabelaCliente;               

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
                
            }

        }

        #endregion

        #region ListarClientePorNome
        
        public DataTable ListarClientePorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome"; // like pesquisa por aproximação

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                //Fechar a conexao
                Conexao.Close();

                return tabelaCliente;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region RetornaClientePorCpf

        public Cliente RetonarClientePorCpf(string cpf)
        {
            try
            {
                // Criar o comando sql e o objeto Cliente
                Cliente obj = new Cliente();
                string sql = @"select  * from tb_clientes where cpf = @cpf";

                //Organizar  o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@cpf", cpf);

                Conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.Codigo = rs.GetInt32("id");
                    obj.Nome = rs.GetString("nome");
                }
                else
                {
                    MessageBox.Show("Cliente não encontrato");
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
