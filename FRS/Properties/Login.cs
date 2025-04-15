using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRS.Properties
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg;
            if (txtusername.Text == "admin" && txtpassword.Text == "1234")
            {
                msg = "Login Successful";
                MessageBox.Show(msg, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 ds = new Form2();
                ds.Show();
                this.Hide();
            }
            else
            {
                msg = "Invalid username or password!";
                MessageBox.Show(msg, "Authentication", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
