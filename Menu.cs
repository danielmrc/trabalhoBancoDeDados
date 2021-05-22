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

   

    public partial class Menu : Form
    {
        MySqlConnection connection;
        MySqlDataAdapter da;

        private int id = 0;
        public Menu()
        {
            InitializeComponent();
            listar();
        }
         

        public void listar()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");


                String sql = "select c.disciplinaId, b.nome as NOME_PROFESSOR, a.horario, c.nome as NOME_DISCIPLINA from professor_disciplina x join professor b on b.professorId = x.professorId right join disciplina c on c.disciplinaId = x.disciplinaId join horario a on a.horarioId = c.horarioId;";

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
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadastraProfessor cProfessor = new cadastraProfessor();
            cProfessor.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cadastraDisciplina cDisciplina = new cadastraDisciplina();
            cDisciplina.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listaProfessor lProfessor = new listaProfessor();
            lProfessor.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaDisciplina lDisciplina = new listaDisciplina();
            lDisciplina.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            relacionarProfessor rP = new relacionarProfessor(id);
            rP.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}




