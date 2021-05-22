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
    public partial class alterarProfessor : Form
    {
        MySqlConnection connection;
        MySqlCommand comando;
        MySqlDataReader dr;

        private String nome;
        private String endereco;
        private DateTime dataNasc;


        int id = 0;
        public alterarProfessor(int id)
        {
            InitializeComponent();
            this.id = id;
            setarValores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alterar();

            listaProfessor lp = new listaProfessor();
            lp.Show();

        }

        public void alterar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String strsql = "UPDATE professor SET nome = @NOME, endereco = @ENDERECO, dataNasc = @DATA WHERE professorId = @ID";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@ID", id);

                nome = textBox1.Text;
                endereco = textBox2.Text;
                dataNasc = dateTimePicker1.Value;


                comando.Parameters.AddWithValue("@NOME", nome);
                comando.Parameters.AddWithValue("@ENDERECO", endereco);
                comando.Parameters.AddWithValue("@DATA", dataNasc);


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
                MessageBox.Show("Alteração feita com sucesso!!");
                Close();
            }

        }

        public void setarValores()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String strsql = "SELECT * from professor WHERE professorId = @ID";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@ID", id);

                connection.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    textBox1.Text = Convert.ToString(dr["nome"]);
                    textBox2.Text = Convert.ToString(dr["endereco"]);
                    dateTimePicker1.Value = Convert.ToDateTime(dr["dataNasc"]);
                }

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

            }
        }

    }
}

