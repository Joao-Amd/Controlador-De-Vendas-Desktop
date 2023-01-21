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
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtcep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txttelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //Receber os dados dentro do objeto modelo de Fornecedores
            Fornecedor obj = new Fornecedor();

            obj.Nome = txtnome.Text;
            obj.Cpf = txtcnpj.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Complemento = txtcomplemento.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.Text;

            //Criar um objeto da classe ClienteDAO e chamar o metado cadastraCliente
            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(obj);

            //Recarregar o datagridview
            tabelaFornecedor.DataSource = dao.ListarFornecedor();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            //Botao consultar CEP
            try
            {
                string cep = txtcep.Text;
                string xml = $"https://viacep.com.br/ws/{cep}/xml/";
                DataSet dados = new DataSet();

                dados.ReadXml(xml);
                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado, por favor  digite manualmente.");
            }
        }

        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            string nome = txtpesquisa.Text;
            FornecedorDAO dao = new FornecedorDAO();

            tabelaFornecedor.DataSource = dao.BuscarFornecedorPorNome(nome);

            if (tabelaFornecedor.Rows.Count == 0)
            {
                //Recarregar o datagridview
                tabelaFornecedor.DataSource = dao.ListarFornecedor();
            }
            nome = "%" + txtpesquisa.Text + "%";
            tabelaFornecedor.DataSource = dao.ListarFornecedorPorNome(nome);
            
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //Receber os dados dentro do objeto modelo de cliente
            Fornecedor obj = new Fornecedor();

            obj.Nome = txtnome.Text;
            obj.Cpf = txtcnpj.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Complemento = txtcomplemento.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.Text;

            obj.Codigo = int.Parse(txtcodigo.Text);

            //Criar um objeto da classe ClienteDAO e chammar o metado Alterar
            FornecedorDAO dao = new FornecedorDAO();
            dao.AlterarFornecedor(obj);

            // recarregar o datagridview
            tabelaFornecedor.DataSource = dao.ListarFornecedor();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {

            //Botao excluir
            Fornecedor obj = new Fornecedor();

            //pegar o codigo
            obj.Codigo = int.Parse(txtcodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();

            dao.ExcluirFornecedor(obj);

            // recarregar o datagridview
            tabelaFornecedor.DataSource = dao.ListarFornecedor();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void tabelaFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar os dados da linha selecionada
            txtcodigo.Text = tabelaFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = tabelaFornecedor.CurrentRow.Cells[2].Value.ToString();          
            txtemail.Text = tabelaFornecedor.CurrentRow.Cells[3].Value.ToString();
            txttelefone.Text = tabelaFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtcelular.Text = tabelaFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text = tabelaFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtendereco.Text = tabelaFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtnumero.Text = tabelaFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtcomplemento.Text = tabelaFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = tabelaFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtcidade.Text = tabelaFornecedor.CurrentRow.Cells[11].Value.ToString();
            txtuf.Text = tabelaFornecedor.CurrentRow.Cells[12].Value.ToString();


            //Alterar para a gui Dados Pessoais
            tabControl1.SelectedTab = tabPage1;
        }

        
    }
}
