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

        public void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\evert\OneDrive\Documentos\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                string SQLrefresh = "SELECT * FROM clientes";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQLrefresh, conn);

                DataSet DS = new DataSet();

                adapter.Fill(DS,"clientes");

                DgResultado.DataSource = DS.Tables["clientes"];
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        public void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadCliente frm = new FrmCadCliente();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.Text = "";

            frm.LblTitulo.Text = "Alterar cadastro";


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

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\evert\OneDrive\Documentos\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                string cod = DgResultado.SelectedCells[0].Value.ToString();
                string SQL = "DELETE FROM clientes WHERE codigo =" + cod;

                OleDbCommand cmd = new OleDbCommand(SQL,conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados deletados com sucesso");

                button1_Click_1(sender, e);
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }
    }
}
