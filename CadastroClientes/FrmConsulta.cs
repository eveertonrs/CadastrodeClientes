using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CadastroClientes
{
    public partial class FrmConsulta : Form
    {
        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\evert\OneDrive\Documentos\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                string SQL = "SELECT * FROM clientes";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL,conn);

                DataSet DS = new DataSet();

                adapter.Fill(DS,"clientes");

                DgResultado.DataSource = DS.Tables["clientes"];
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadCliente frm = new FrmCadCliente();
            frm.Codigo = DgResultado.SelectedCells[0].Value.ToString();
            frm.txtNome.Text = DgResultado.SelectedCells[1].Value.ToString();
            frm.txtTelefone.Text = DgResultado.SelectedCells[3].Value.ToString();
            frm.txtEmail.Text = DgResultado.SelectedCells[2].Value.ToString();
            frm.txtEnd.Text = DgResultado.SelectedCells[4].Value.ToString();
            frm.txtData.Text = DgResultado.SelectedCells[5].Value.ToString();
            frm.button1.Visible = false;
            frm.button2.Visible = true;
            frm.ShowDialog();
        }
    }
}
