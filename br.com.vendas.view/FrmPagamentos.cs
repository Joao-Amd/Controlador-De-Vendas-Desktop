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

        private void btnnovo_Click(object sender, EventArgs e)
        {
            

            try
            {
                //botao finalizar venda
                
                decimal vDinheiro, vCartao, vPix, troco, totalPago,total;
                int quantidadeEstoque, quantidadeComprada, estoqueAtualizada;
                ProdutoDAO daoProduto = new ProdutoDAO();

                vDinheiro = decimal.Parse(txtdinheiro.Text);
                vCartao = decimal.Parse(txtcartao.Text);
                vPix = decimal.Parse(txtpix.Text);
                total = decimal.Parse(txttotal.Text);

                //calcular o total pago
                totalPago = vDinheiro + vCartao + vPix;

                if(totalPago < total)
                {
                    MessageBox.Show("O valor  pago  é menor que valor total da venda");
                }
                else
                {
                    //Calcular o troco
                    troco = totalPago - total;
                    Venda vendas = new Venda();

                    vendas.ClienteId = Cliente.Codigo;
                    vendas.DataVenda = DataAtual;
                    vendas.TotalVendas = total;
                    vendas.Obs = txtobs.Text;

                    VendasDAO vdao = new VendasDAO();
                    
                    txttroco.Text = troco.ToString();
                    vdao.CadastrarVenda(vendas);

                    //Cadastrar os itens da venda

                    foreach (DataRow  linha in Carrinho.Rows)
                    {
                        ItemVendas item = new ItemVendas();
                        item.VendaId = vdao.RetornarIdUltimaVenda();
                        item.ProdutoId = int.Parse(linha["Código"].ToString());
                        item.Quantidade = int.Parse(linha["Quantidade"].ToString());
                        item.SubTotal = decimal.Parse(linha["Subtotal"].ToString());

                        // Baixar Estoque
                        quantidadeEstoque = daoProduto.retornarEstoqueAtual(item.ProdutoId);
                        quantidadeComprada = item.Quantidade;
                        estoqueAtualizada = quantidadeEstoque - quantidadeComprada;

                        daoProduto.BaixarEstoque(item.ProdutoId, estoqueAtualizada);

                        ItemVendasDAO itemDao = new ItemVendasDAO();
                        itemDao.CadastarItemVenda(item);
                    }

                    MessageBox.Show("Venda Finalizada com sucesso");
                    this.Dispose();

                    new FrmVendas().ShowDialog();
                   
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmPagamentos_Load(object sender, EventArgs e)
        {
            //carrega tela
            txttroco.Text = "0,00";
            txtdinheiro.Text = "0,00";
            txtcartao.Text = "0,00";
            txtpix.Text = "0,00";
        }

        private void txtdinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
