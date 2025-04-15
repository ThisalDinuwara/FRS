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
    public partial class Passenger : Form
    {
        public Passenger()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
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
                if (comboBox1.Text.Length <= 0)
                {
                    MessageBox.Show("Num of Seats can not be empty", "Error");
                    return;
                }

                string query = "INSERT INTO recordpassenger (Passenger_Id, Passport_No, Name, Address, Nationality, Phone_No) VALUES (@Passenger_Id, @Passport_No, @Name, @Address, @Nationality, @Phone_No)";
                Connection cn = new Connection();
                MySqlCommand cmd = new MySqlCommand(query, cn.GetConnection());

                cmd.Parameters.AddWithValue("@Passenger_Id", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@Passport_No", textBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@Name", textBox3.Text.ToString());
                cmd.Parameters.AddWithValue("@Address", textBox4.Text.ToString()); // Corrected the property
                cmd.Parameters.AddWithValue("@Nationality", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@Phone_No", textBox5.Text.ToString());
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
                finally
                {
                    cn.CloseConnection();
                }
            }


            /*if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Flight Code can not be empty", "Error");
                return;
            }
            if (comboBox1.Text.Length <= 0)
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
            string query = "INSERT INTO Record Flight(Flight_Code,From_location,To_location,Take_off_Date,Num_of_Seats) VALUES(@Flight_Code,@From,@To,@Take_off_Date,@Num_of_Seats)";
            Connection cn = new Connection();
            //cn.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, cn.GetConnection());
            cmd.Parameters.AddWithValue("@Flight_Code", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@From", comboBox1.Text.ToString());
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
            cn.CloseConnection();*/
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 ds = new Form4();
            ds.Show();
            this.Hide();
        }

        private void Passenger_Load(object sender, EventArgs e)
        {

        }
    }
}
