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
    public partial class FrmHistoricoVendas : Form
    {
        public FrmHistoricoVendas()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio, dataFim;

            dataInicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy-MM-dd"));
            dataFim = Convert.ToDateTime(dtFim.Value.ToString("yyyy-MM-dd"));

            VendasDAO dao = new VendasDAO();
            tabelaHistorico.DataSource = dao.ExibirHistoricoVenda(dataInicio,dataFim);
        }

        private void FrmHistoricoVendas_Load(object sender, EventArgs e)
        {
            VendasDAO dao = new VendasDAO();

            tabelaHistorico.DataSource = dao.ListarVendas();
            tabelaHistorico.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void tabelaHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Abrir formulario e Passar Id da Venda
                int idVenda = int.Parse(tabelaHistorico.CurrentRow.Cells[5].Value.ToString());

                FrmDetalhes tela = new FrmDetalhes(idVenda);

                //formatarData
                DateTime dataVenda = Convert.ToDateTime(tabelaHistorico.CurrentRow.Cells[6].Value.ToString());

                tela.txtdata.Text = dataVenda.ToString("dd/MM/yyyy");
                tela.txtcliente.Text = tabelaHistorico.CurrentRow.Cells[7].Value.ToString();
                tela.txttotal.Text = tabelaHistorico.CurrentRow.Cells[8].Value.ToString();
                tela.txtobs.Text = tabelaHistorico.CurrentRow.Cells[9].Value.ToString();


                tela.ShowDialog();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro" + erro);
            }
           
        }

        private void tabelaHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
