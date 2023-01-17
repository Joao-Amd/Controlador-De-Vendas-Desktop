using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.dao
{
    internal class FuncionarioDAO
    {

        private MySqlConnection Conexao;

        public FuncionarioDAO()
        {
            Conexao = new ConnectionFactory().GetConnection();
        }
        #region CadastrarFuncionario
        public void CadastrarFuncionarios(Funcionario obj)
        {
            try
            {
                // definir o cmd sql - insert into

                string sql = @"insert into tb_funcionarios (nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                             values (@nome,@rg,@cpf,@email,@senha,@cargo,@nivel_acesso,@telefone,@celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado) ";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@senha", obj.Senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.Cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.NivelAcesso);
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

                MessageBox.Show("Cliente Cadastrado com sucesso!");

                // Fechar conexao
                Conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro: " + erro);

            }
        }

        #endregion
   
        #region AlterarFuncionario

        public void AlterarFuncionario(Funcionario obj)
        {
            try
            {
                //  definir o cmd sql  - Update
                string sql = @"update tb_funcionarios (nome=@nome,rg=@rg,cpf=@cpf,email=@email,senha=@senha,cargo=@cargo,nivel_acesso=@nivel_acesso,telefone=@telefone,celular=@celular,cep=@cep,
                            endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado)
                            where id=@id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@senha", obj.Senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.Cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.NivelAcesso);
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

                MessageBox.Show("Funcionario Alterado com sucesso!");

                //Fechar a conexao
                Conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro);
            }
        }

        #endregion

        #region ExcluirFuncionario
        public void ExcluirFuncionario(Cliente obj)
        {
            try
            {
                //  definir o cmd sql  - delete
                string sql = @"delete from tb_funcionarios where id = @id";

                //Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);


                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                // Abrir a conexao e executar o comando sql
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario Excluido com sucesso!");

                //Fechar a conexao
                Conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ListarFuncionario

        public DataTable ListarFuncionario()
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                //Fechar a conexao
                Conexao.Close();
                return tabelaFuncionario;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }



        #endregion

        #region BuscarFuncionarioPorNome
        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                // DateTable com e o comando sql
                DataTable tabelaFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome = @nome";

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                //Fechar a conexao

                Conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }
        #endregion

        #region ListarFuncionarioPorNome

        public DataTable ListarFuncionarioPorNome(string nome)
        {
            try
            {   // DateTable com e o comando sql
                DataTable tabelaFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome like @nome"; // like pesquisa por aproximação

                //  Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, Conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                Conexao.Open();
                executacmd.ExecuteNonQuery();

                // Criar o MySQLDataApter para preencher  os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                //Fechar a conexao
                Conexao.Close();

                return tabelaFuncionario;

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
