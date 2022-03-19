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

namespace bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            // count = count + 1;
            username = txtuser.Text;
            password = txtpass.Text;

            // Database new connection...

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE username = @usn and password = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            //command.Parameters.Add("@type", MySqlDbType.VarChar).Value = usertype;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // ends database connections...



            /* if (count > 3)
             {
                 MessageBox.Show("System has been blocked.........");
                 Application.Exit();
             }

             */

            if (username == "" && password == "")
            {
                label4.Text = "Blank not be allowed";
            }
            else if (username.Length >= 10 && password.Length >= 10)
            {
                label4.Text = "10 Character only allowed";
            }
            else
            {
                //if (username == "iqbal" && password == "sunny")
                 if (table.Rows.Count > 0)
                {
                    // label4.Text = "Login Successfully";
                    progessbar pr = new progessbar();
                    this.Hide();
                    pr.Show();
                }
                 else
                {
                    label4.Text = "Invalid User and Password";
                    txtuser.Clear();
                    txtpass.Clear();
                    txtuser.Focus();
                }
            }
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text =  "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Confirm_Click(object sender, EventArgs e)
        {

        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
