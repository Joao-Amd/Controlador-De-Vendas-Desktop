using System.Configuration;
using MySql.Data.MySqlClient;

namespace ProjetoVendas.br.com.vendas.conexao
{
    public class ConnectionFactory
    {
        //metado que conecta o banco  de dados
        public MySqlConnection GetConnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            return new MySqlConnection(conexao);
        }
    }
}