using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TrabalhoBD
{
    public partial class cadastraProfessor : Form
    {
        MySqlConnection connection;
        MySqlCommand comando;

        public cadastraProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadastra();
        }

        public void cadastra()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String strsql = "INSERT INTO professor (nome, endereco, dataNasc) values(@NOME, @ENDERECO, @DATANASC);";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@NOME", textNome.Text);
                comando.Parameters.AddWithValue("@ENDERECO", textEndereco.Text);
                comando.Parameters.AddWithValue("@DATANASC", dateTimePicker1.Value);

                connection.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                comando = null;
                MessageBox.Show("Cadastro feito com sucesso!!");
                Close();
            }
        }

      
    }
}
