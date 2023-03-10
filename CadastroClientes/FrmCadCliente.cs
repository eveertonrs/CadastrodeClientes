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
        
        private bool ValidaNome()
        {
            return (txtNome.TextLength >= 7);
        }
        private bool ValidaEmail()
        {
            return (txtEmail.TextLength >= 10);
        }
        private bool ValidaEnd()
        {
            return (txtEnd.TextLength >= 10);
        }
        private bool ValidaTelefone()
        {
            return (txtTelefone.TextLength >= 9);
        }
        private bool ValidaData()
        {
            return (txtData.TextLength <= 10);
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



                if (ValidaNome() && ValidaTelefone() && ValidaEnd())
                {
                    string SQL;
                    SQL = "INSERT INTO clientes(Nome,Email,Telefone,Endereco,DataNasc) VALUES ";
                    SQL += "('" + txtNome.Text + "', '" + txtEmail.Text + "', '" + txtTelefone.Text + "', '" + txtEnd.Text + "', '" + txtData.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(SQL, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrados com sucesso");
                    txtData.Clear();
                    txtEmail.Clear();
                    txtEnd.Clear();
                    txtNome.Clear();
                    txtTelefone.Clear();
                    Close();

                }
                else
                {
                    MessageBox.Show("Por favor preencha todos os campos, ou verifique as informações");
                }
                

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

                //SQL = "UPDATE clientes SET Nome ='" + txtNome.Text + "',";
                //SQL += " Telefone = '" + txtTelefone.Text + "',";
                //SQL += " Email = '" + txtEmail.Text + "',";
                //SQL += " Endereco = '" + txtEnd.Text + "',";
                //SQL += " DataNasc = '" + txtData.Text + "'";
                //SQL += " WHERE Codigo = " + Codigo;



                SQL = "UPDATE clientes SET ";
                SQL += "Nome ='" + txtNome.Text + "', Email = '" + txtEmail.Text + "', Telefone = '" + txtTelefone.Text + "', Endereco = '" + txtEnd.Text + "', DataNasc = '" + txtData.Text + "'";
                SQL += " WHERE Codigo = " + Codigo;



                OleDbCommand cmd = new OleDbCommand(SQL, conn);

                cmd.ExecuteNonQuery();


                MessageBox.Show("Dados do cliente alterado com sucesso");
            
                txtData.Clear();
                txtEmail.Clear();
                txtEnd.Clear();
                txtNome.Clear();
                txtTelefone.Clear();


                conn.Close();


                Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaNome())
            {
                errorNome.SetError(txtNome, "Preenche com o nome completo");
            }
            else
            {
                errorNome.SetError(txtNome, string.Empty);
            }
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaData())
            {
                errorData.SetError(txtData, "Preenche o campo Data de nascimento");
            }
            else
            {
                errorData.SetError(txtData, string.Empty);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaEmail())
            {
                errorEmail.SetError(txtEmail, "Preenche o Email");
            }
            else
            {
                errorEmail.SetError(txtEmail, string.Empty);
            }
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaTelefone())
            {
                errorTelefone.SetError(txtTelefone, "Celular no minimo com 9 digitos");
            }
            else
            {
                errorTelefone.SetError(txtTelefone, string.Empty);
            }
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            if (!ValidaEnd())
            {
                errorEnd.SetError(txtEnd, "Colocar nome da Rua, Numero - Bairro ");
            }
            else
            {
                errorEnd.SetError(txtEnd, string.Empty);
            }
        }
    }
}
