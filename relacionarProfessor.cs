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
    public partial class relacionarProfessor : Form
    {
        MySqlConnection connection;
        MySqlCommand comando;
        MySqlDataAdapter da;


        int disciplinaId = 0;
        int professorId = 0;

        public relacionarProfessor(int discId)
        {
            InitializeComponent();
            this.disciplinaId = discId;
            listar();
        }

        public void listar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");


                String sql = "SELECT * FROM professor;";

                DataTable dt = new DataTable();

                da = new MySqlDataAdapter(sql, connection);

                da.Fill(dt);

                dataGridView1.DataSource = dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.professorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            associa();
        }

        public void associa()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String strsql = "INSERT INTO professor_disciplina(professorId, disciplinaId) values(@PROFESSORID, @DISCIPLINAID);";

                comando = new MySqlCommand(strsql, connection);

                comando.Parameters.AddWithValue("@PROFESSORID", professorId);
                comando.Parameters.AddWithValue("@DISCIPLINAID", disciplinaId);

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
                MessageBox.Show("Associação Feita com sucesso!!");
                Close();
            }
        }
    }
}
