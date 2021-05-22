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
    public partial class alterarDisciplina : Form
    {
        MySqlConnection connection;
        MySqlCommand comando;
        MySqlDataReader dr;

        private int id;

        private String nome;
        private String horario;
        private String periodo;

        public alterarDisciplina(int id)
        {
            InitializeComponent();
            this.id = id;
            setarValores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alterar();


            listaDisciplina listd = new listaDisciplina();
            listd.Show();

        }

        public void alterar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String strsql = "UPDATE disciplina SET nome = @NOME, periodo = @PERIODO, horarioId = (SELECT horarioId FROM horario WHERE horario = @HORARIO) WHERE disciplinaId = @ID";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@ID", id);

                nome = textBox1.Text;
                periodo = textPeriodo.Text;
                horario = textHorario.Text;


                comando.Parameters.AddWithValue("@NOME", nome);
                comando.Parameters.AddWithValue("@PERIODO", periodo);
                comando.Parameters.AddWithValue("@HORARIO", horario);


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

                String strsql = "SELECT * from disciplina a join horario b on a.horarioId = b.horarioId WHERE disciplinaId = @ID";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@ID", id);

                connection.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    textBox1.Text = Convert.ToString(dr["nome"]);
                    textPeriodo.Text = Convert.ToString(dr["periodo"]);
                    textHorario.Text = Convert.ToString(dr["horario"]);
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
