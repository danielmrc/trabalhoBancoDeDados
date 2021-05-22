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
    public partial class cadastraDisciplina : Form
    {

        MySqlConnection connection;
        MySqlCommand comando;
        public cadastraDisciplina()
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

                String strsql = "INSERT INTO disciplina (nome, periodo, horarioId) values(@NOME, @PERIODO,(select horarioId from horario where horario =  @HORARIO));";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@NOME", textNome.Text);
                comando.Parameters.AddWithValue("@PERIODO", textPeriodo.Text);
                comando.Parameters.AddWithValue("@HORARIO", textHorario.Text);

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
