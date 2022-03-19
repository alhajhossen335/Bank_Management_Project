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
    public partial class loandetalis : Form
    {
        public loandetalis()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox1.Text != "")
            {
                cmd = new MySqlCommand("select Loan_amount , Loan_pm from loan where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                string pm = "";
                while (da.Read())
                {
                    textBox2.Text = da.GetValue(0).ToString();
                    pm = da.GetValue(1).ToString();
                }
                con.Close();
                int a = Int32.Parse(textBox2.Text);
                int b = Int32.Parse(pm);
                if(a >= b)
                {
                    textBox3.Text = pm;
                } else
                {
                    textBox3.Text = textBox2.Text;
                }
            }
            else
            {

                MessageBox.Show("invalid Account");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();
            int a = Int32.Parse(textBox2.Text);
            int b = Int32.Parse(textBox3.Text);
            int res = a - b;
            MySqlCommand cmd = new MySqlCommand("update loan set Loan_amount ='" + res + "' where Accountno='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully paid");
            con.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main on = new Main();
            on.Show();
            this.Hide();
        }
    }
}
