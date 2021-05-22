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

    public partial class listaProfessor : Form
    {

        MySqlConnection connection;
        MySqlCommand comando;
        MySqlDataAdapter da;

        int id = 0;
        public listaProfessor()
        {
            InitializeComponent();
            listar();
        }

        private void listaProfessor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleta();
        }


        public void deleta()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=trabbd;Uid=root;Pwd=");

                String sql = "DELETE FROM professor WHERE professorId = @ID";

                comando = new MySqlCommand(sql, connection);


                comando.Parameters.AddWithValue("@ID", id);

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
                listar();
            }
        }


        public void alterar()
        {
            alterarProfessor ap = new alterarProfessor(id);
            ap.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            alterar();
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

 
    }


}

