using ProjetoVendas.br.com.vendas.dao;
using ProjetoVendas.br.com.vendas.model;
using System;
using System.Windows.Forms;

namespace ProjetoVendas.br.com.vendas.view
{
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtcep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txttelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtfornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            FornecedorDAO fDao = new FornecedorDAO();

            cbfornecedor.DataSource = fDao.ListarFornecedor();
            cbfornecedor.DisplayMember = "nome";
            cbfornecedor.ValueMember = "id";

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProdutos.DataSource = dao.ListarProduto();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Produtos obj = new Produtos();

            obj.Descricao = txtdescricao.Text;
            obj.QuantidadeEstoque = int.Parse(txtquantidade.Text);
            obj.Preco = decimal.Parse(txtpreco.Text);
            obj.For_id = int.Parse(cbfornecedor.SelectedValue.ToString());

            ProdutoDAO dao = new ProdutoDAO();
            dao.cadastrarProduto(obj);

            //Recarregar o datagridview
            tabelaProdutos.DataSource = dao.ListarProduto();

            //Limpar Tela
            new Helpers().LimparTela(this);


        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void tabelaProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar os dados da linha selecionada
            txtcodigo.Text = tabelaProdutos.CurrentRow.Cells[0].Value.ToString();
            txtdescricao.Text = tabelaProdutos.CurrentRow.Cells[1].Value.ToString();
            txtpreco.Text = tabelaProdutos.CurrentRow.Cells[2].Value.ToString();
            txtquantidade.Text = tabelaProdutos.CurrentRow.Cells[3].Value.ToString();



            //Alterar para a gui Dados Pessoais
            tabProdutos.SelectedTab = tabPage1;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Produtos obj = new Produtos();

            obj.Descricao = txtdescricao.Text;
            obj.QuantidadeEstoque = int.Parse(txtquantidade.Text);
            obj.Preco = decimal.Parse(txtpreco.Text);
            obj.For_id = int.Parse(cbfornecedor.SelectedValue.ToString());
            obj.Id = int.Parse(txtcodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.AlterarProduto(obj);

            //Recarregar o datagridview
            tabelaProdutos.DataSource = dao.ListarProduto();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            Produtos obj = new Produtos();

            
            obj.Id = int.Parse(txtcodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.ExcluirProduto(obj);

            //Recarregar o datagridview
            tabelaProdutos.DataSource = dao.ListarProduto();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            string nome  = txtpesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.BuscarProdutosPorNome(nome);

            if(tabelaProdutos.Rows.Count == 0)
            {
                //recarregar o datagridview
                tabelaProdutos.DataSource = dao.ListarProduto();
            }
            

            nome = "%" + txtpesquisa.Text + "%";       
            tabelaProdutos.DataSource= dao.ListarProdutosPorNome(nome);
        }
    }
}
