using ProjetoVendas.br.com.vendas.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.view
{
    public partial class FrmDetalhes : Form
    {
        int IdVenda;
        public FrmDetalhes(int idVenda)
        {
            IdVenda = idVenda;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmDetalhes_Load(object sender, EventArgs e)
        {
            //Carregar tela de detalhes
            ItemVendasDAO dao = new ItemVendasDAO();
            tabelaDetalhes.DataSource = dao.ListarItensVenda(IdVenda);
        }

        private void tabelaDetalhes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
