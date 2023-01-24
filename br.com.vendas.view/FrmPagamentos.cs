using ProjetoVendas.br.com.vendas.model;
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
    public partial class FrmPagamentos : Form
    {
        Cliente Cliente = new Cliente();
        DataTable Carrinho = new DataTable();
        DateTime DataAtual;
        public FrmPagamentos(Cliente cliente, DataTable carrinho, DateTime dataAtual)
        {
            Cliente = cliente; 
            Carrinho = carrinho;
            DataAtual = dataAtual;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
