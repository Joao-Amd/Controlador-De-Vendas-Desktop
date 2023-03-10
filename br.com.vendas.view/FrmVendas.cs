using ProjetoVendas.br.com.vendas.dao;
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
    public partial class FrmVendas : Form
    {
        //Objetos Cliente e ClienteDAO
        Cliente cliente = new Cliente();
        ClienteDAO cdao = new ClienteDAO();

        //Objetos Produtos e ProdutosDAO 
        Produtos produtos = new Produtos();
        ProdutoDAO pdao = new ProdutoDAO();

        //Variaveis

        int quantidade;
        decimal preco;
        decimal subtotal;
        decimal totalizador;
        //carrinho
        DataTable carrinho = new DataTable();

        public FrmVendas()
        {

            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Quantidade", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tabelaProdutos.DataSource = carrinho;
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtquantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Busca cliente por cpf com a tecla enter
            if (e.KeyChar == 13)
            {
                cliente = cdao.RetonarClientePorCpf(txtcpf.Text);

                if (cliente != null)
                {
                    txtnome.Text = cliente.Nome;
                }
                else
                {
                    txtcpf.Clear();
                    txtcpf.Focus();                  
                }
            }

           


        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Busca cliente por cpf com a tecla enter
            if (e.KeyChar == 13)
            {
                produtos = pdao.RetonarProdutoPorCodigo(int.Parse(txtcodigo.Text));
                if(produtos != null)
                {
                    txtdescricao.Text = produtos.Descricao;
                    txtpreco.Text = produtos.Preco.ToString();
                }

                else
                {                   
                    txtcodigo.Clear();
                    txtcodigo.Focus();
                    MessageBox.Show("Produto não encontrado");
                }
                
            }
        }


        private void FrmVendas_Load(object sender, EventArgs e)
        {
            //Pegar a data atual
            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void btadcionar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botao adcionar item

                quantidade = int.Parse(txtquantidade.Text);
                preco = decimal.Parse(txtpreco.Text);

                subtotal = quantidade * preco;

                totalizador += subtotal;

                //adcionar o produto no carrinho
                carrinho.Rows.Add(int.Parse(txtcodigo.Text), txtdescricao.Text, quantidade, preco, subtotal);

                txttotal.Text = totalizador.ToString();

                //Limpar os campos
                txtcodigo.Clear();
                txtdescricao.Clear();
                txtquantidade.Clear();
                txtpreco.Clear();

                txtcodigo.Focus();
            }

            catch (Exception erro)
            {
                MessageBox.Show("Digite o código do produto" + erro);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btremover_Click(object sender, EventArgs e)
        {
            //Botao remover item
            decimal subproduto = decimal.Parse(tabelaProdutos.CurrentRow.Cells[4].Value.ToString());
            int indice = tabelaProdutos.CurrentRow.Index;

            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();
            totalizador -= subproduto;


            txttotal.Text = total.ToString();

            MessageBox.Show("Item Removido do carrinho com sucesso!");

        }

        private void btnpagamento_Click(object sender, EventArgs e)
        {
            //Botão Pagamento
            DateTime dataAtual = DateTime.Parse(txtdata.Text);
            FrmPagamentos tela = new FrmPagamentos(cliente, carrinho, dataAtual);

            //Passando  o total para  tela de pagamentos

            tela.txttotal.Text = totalizador.ToString();
            tela.Show();
        }

        private void txtpreco_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
