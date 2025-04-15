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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length <= 0)
            {
                MessageBox.Show("Flight Number can not be empty", "Error");
                return;
            }
            if (comboBox3.Text.Length <= 0)
            {
                MessageBox.Show("From can not be empty", "Error");
                return;
            }
            if (comboBox2.Text.Length <= 0)
            {
                MessageBox.Show("To can not be empty", "Error");
                return;
            }
            if (dateTimePicker1.Text.Length <= 0)
            {
                MessageBox.Show("Take off Date can not be empty", "Error");
                return;

            }
            if (textBox2.Text.Length <= 0)

            {

                MessageBox.Show("Num of Seats can not be empty", "Error");
                return;
            }
            string query = "INSERT INTO view_sheduled_flight(Flight_Number,From_location,To_location,Take_off_Date,Num_of_Seats) VALUES(@Flight_Number,@From,@To,@Take_off_Date,@Num_of_Seats)";
            Connection cn = new Connection();
            //cn.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, cn.GetConnection());
            cmd.Parameters.AddWithValue("@Flight_Number", comboBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@From", comboBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@To", comboBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@Take_off_Date", dateTimePicker1.Text.ToString());
            cmd.Parameters.AddWithValue("@Num_of_Seats", dateTimePicker1.Text.ToString());
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

            {
                Passenger ds = new Passenger();
                ds.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Passenger ds = new Passenger();
            ds.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Form3_Load(object sender, EventArgs e)
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
    }
}
