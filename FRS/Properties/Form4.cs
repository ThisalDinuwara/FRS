using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FRS.Properties
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Flight Code can not be empty", "Error");
                return;
            }
            if (textBox2.Text.Length <= 0)
            {
                MessageBox.Show("From can not be empty", "Error");
                return;
            }
            if (textBox3.Text.Length <= 0)
            {
                MessageBox.Show("To can not be empty", "Error");
                return;
            }
            if (textBox4.Text.Length <= 0)
            {
                MessageBox.Show("Take off Date can not be empty", "Error");
                return;

            }
            if (comboBox1.Text.Length <= 0)

            {

                MessageBox.Show("Num of Seats can not be empty", "Error");
                return;
            }
            string query = "INSERT INTO Record Flight(Flight_Code,From :,To :,Take_off_Date,Num_of_Seats) VALUES(@Flight_Code,@From :,@To :,@Take_off_Date,@Num_of_Seats)";
            Connection cn = new Connection();
            //cn.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, cn.GetConnection());
            cmd.Parameters.AddWithValue("@Flight_Code", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@From :", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@To :", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@Take_off_Date", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("@Num_of_Seats", comboBox1.Text.ToString());
            cmd.Parameters.AddWithValue("", DateTime.Now);
            try
            {
                cn.OpenConnection();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Confirmed.");
                }
                else
                {
                    MessageBox.Show("Failed to insert data.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            cn.CloseConnection();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Connection cn = new Connection();
            cn.GetConnection();
            cn.OpenConnection();
            dataGridView1.DataSource = null;
            //show table
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from books", cn.GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            Connection connct = new Connection();
            connct.GetConnection();
            connct.OpenConnection();

            dataGridView1.DataSource = null;

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM recordflight",
            connct.GetConnection());

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value?.ToString();
                textBox2.Text = row.Cells[3].Value?.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();


                
            }
        }
    }
}
