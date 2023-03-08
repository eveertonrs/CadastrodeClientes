using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CadastroClientes
{
    public partial class FrmCadCliente : Form
    {
        public FrmCadCliente()
        {
            InitializeComponent();
        }

        public String Codigo;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\evert\OneDrive\Documentos\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                string SQL;
                SQL = "INSERT INTO clientes(Nome,Email,Telefone,Endereco,DataNasc) VALUES ";
                SQL +="('"+txtNome.Text+"', '"+txtEmail.Text+"', '"+txtTelefone.Text +"', '"+txtEnd.Text +"', '"+txtData.Text +"')";
                OleDbCommand cmd = new OleDbCommand(SQL,conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrados com sucesso");

                txtData.Clear();
                txtEmail.Clear();
                txtEnd.Clear();
                txtNome.Clear();
                txtTelefone.Clear();

                conn.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\evert\OneDrive\Documentos\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                string SQL;

                SQL = "UPDATE clientes SET Nome ='" + txtNome.Text + "',";
                SQL += " Telefone = '" + txtTelefone.Text + "',";
                SQL += " Email = '" + txtEmail.Text + "',";
                SQL += " Endereco = '" + txtEnd.Text + "',";
                SQL += " DataNasc = '" + txtData.Text + "'";
                SQL += " WHERE Codigo = " + Codigo;



                //SQL = "UPDATE clientes SET ";
                //SQL += "Nome ='" + txtNome.Text + "', Email = '" + txtEmail.Text + "', Telefone = '" + txtTelefone.Text + "', Endereco = '" + txtEnd.Text + "', DataNasc = '" + txtData.Text + "'";
                //SQL += " WHERE Codigo = " + Codigo;

                OleDbCommand cmd = new OleDbCommand(SQL, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados do cliente alterado com sucesso");

                txtData.Clear();
                txtEmail.Clear();
                txtEnd.Clear();
                txtNome.Clear();
                txtTelefone.Clear();

                conn.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }
    }
}
