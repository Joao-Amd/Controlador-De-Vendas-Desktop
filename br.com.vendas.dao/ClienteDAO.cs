using MySql.Data.MySqlClient;
using ProjetoVendas.br.com.vendas.conexao;
using ProjetoVendas.br.com.vendas.model;
using System;
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
                MySqlCommand executacmd = new MySqlCommand(sql,Conexao);

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

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
            
        }
        #endregion
    }
}
