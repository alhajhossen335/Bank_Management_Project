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
    public partial class loan : Form
    {
        public loan()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Form Must be filled!!");
                return;
            }
            
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();


            string query = "insert into loan(Accountno , Date , Loan_amount , Loan_period , Loan_pm) values (@ac ,@dat,@la,@lp,@lm )";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@ac", MySqlDbType.VarChar, 100);
            cmd.Parameters.Add("@dat", MySqlDbType.Date);
            cmd.Parameters.Add("@la", MySqlDbType.Int32);
            cmd.Parameters.Add("@lp", MySqlDbType.Int32);
            cmd.Parameters.Add("@lm", MySqlDbType.Int32);

            cmd.Parameters["@ac"].Value = textBox1.Text;
            cmd.Parameters["@dat"].Value = dateTimePicker1.Value;
            cmd.Parameters["@la"].Value = Int32.Parse(textBox2.Text);
            cmd.Parameters["@lp"].Value = Int32.Parse(textBox3.Text);
            cmd.Parameters["@lm"].Value = Int32.Parse(textBox4.Text);

            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = ""; 
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Loan Create Successfully");
            con.Close();

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main ob = new Main();
            ob.Show();
            this.Hide();
        }
    }
}
