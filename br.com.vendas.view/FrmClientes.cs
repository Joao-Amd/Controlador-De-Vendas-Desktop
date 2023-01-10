using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoVendas.br.com.vendas.dao;
using ProjetoVendas.br.com.vendas.model;
using ProjetoVendas.br.com.vendas.view;

namespace ProjetoVendas.br.com.vendas.view
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaClientes.DataSource = dao.ListarCliente();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Cliente obj = new Cliente();

            //pegar o codigo
            obj.Codigo = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.ExcluirCliente(obj);

            // recarregar o datagridview
            tabelaClientes.DataSource = dao.ListarCliente();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
           //Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
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

            //Criar um objeto da classe ClienteDAO e chammar o metado cadastraCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            //Recarregar o datagridview
            tabelaClientes.DataSource = dao.ListarCliente();

            //Limpar Tela
            new Helpers().LimparTela(this);

        }

        private void tabelaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar os dados da linha selecionada
            txtcodigo.Text = tabelaClientes.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaClientes.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaClientes.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaClientes.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaClientes.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaClientes.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaClientes.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaClientes.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaClientes.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaClientes.CurrentRow.Cells[9].Value.ToString();
            txtcomplemento.Text = tabelaClientes.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaClientes.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaClientes.CurrentRow.Cells[12].Value.ToString();
            txtuf.Text = tabelaClientes.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a gui Dados Pessoais
            tabControl1.SelectedTab = tabPage1;
            
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
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
            ClienteDAO dao = new ClienteDAO();
            dao.AlterarCliente(obj);

            //Recarregar o datagridview
            tabelaClientes.DataSource = dao.ListarCliente();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            //Botao pesquisar
            string nome = txtpesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaClientes.DataSource=dao.BuscarClientePorNome(nome);

            if(tabelaClientes.Rows.Count == 0)
            {
                //Recarregar o datagridview
                tabelaClientes.DataSource = dao.ListarCliente();
            }
            nome = "%" + txtpesquisa.Text + "%";
            tabelaClientes.DataSource = dao.ListarClientePorNome(nome);

        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

            
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

        private void btnnovo_Click(object sender, EventArgs e)
        {

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
