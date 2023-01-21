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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //Receber os dados dentro do objeto modelo de cliente
            Funcionario obj = new Funcionario();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.Senha = txtsenha.Text;
            obj.Cargo = cbcargo.Text;
            obj.NivelAcesso = cbnivel.Text;
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
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.CadastrarFuncionarios(obj);

            //Recarregar o datagridview
            tabelaFuncionario.DataSource = dao.ListarFuncionario();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Funcionario obj = new Funcionario();

            //pegar o codigo
            obj.Codigo = int.Parse(txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.ExcluirFuncionario(obj);

            // recarregar o datagridview
            tabelaFuncionario.DataSource = dao.ListarFuncionario();

            //Limpar Tela
            new Helpers().LimparTela(this);
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //Receber os dados dentro do objeto modelo de cliente
            Funcionario obj = new Funcionario();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.Senha = txtsenha.Text;
            obj.Cargo = cbcargo.Text;
            obj.NivelAcesso = cbnivel.Text;
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
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.AlterarFuncionario(obj);

            //Recarregar o datagridview
            tabelaFuncionario.DataSource = dao.ListarFuncionario();

            //Limpar Tela
            new Helpers().LimparTela(this);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtcelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtbairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtcep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            string nome = btnpesquisa.Text;

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource=dao.BuscarFuncionarioPorNome(nome);

            if (tabelaFuncionario.Rows.Count == 0)
            {
                //Recarregar o datagridview
                tabelaFuncionario.DataSource = dao.ListarFuncionario();
            }
            nome = "%" + txtpesquisa.Text + "%";
            tabelaFuncionario.DataSource = dao.ListarFuncionarioPorNome(nome);

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
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

        private void tabelaFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tabFuncionario_Click(object sender, EventArgs e)
        {

        }

        private void tabelaFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar os dados da linha selecionada
            txtcodigo.Text = tabelaFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = tabelaFuncionario.CurrentRow.Cells[5].Value.ToString();
            cbcargo.Text = tabelaFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbnivel.Text = tabelaFuncionario.CurrentRow.Cells[7].Value.ToString();
            txttelefone.Text = tabelaFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = tabelaFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = tabelaFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = tabelaFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = tabelaFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtcomplemento.Text = tabelaFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = tabelaFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = tabelaFuncionario.CurrentRow.Cells[15].Value.ToString();
            txtuf.Text = tabelaFuncionario.CurrentRow.Cells[16].Value.ToString();

            //Alterar para a gui Dados Pessoais
            tabControl1.SelectedTab = tabPage1;
        }
    }
    
}
