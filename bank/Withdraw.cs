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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main foo = new Main();
            foo.Show();
        }


        public static string SubTwoStrings(string one, string two)
        {
            int iOne = 0;
            int iTwo = 0;
            Int32.TryParse(one, out iOne);
            Int32.TryParse(two, out iTwo);
            int ans = iOne - iTwo;
            return ans.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox1.Text != "")
            {
                cmd = new MySqlCommand("select Balance from account where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox2.Text = da.GetValue(0).ToString();
                }
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string widr;
            widr = textBox3.Text;
            string bal = "0";
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox1.Text != "")
            {
                cmd = new MySqlCommand("select Balance from account where Accountno='" + textBox1.Text + "'", con);
                //cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox2.Text = da.GetValue(0).ToString();
                    bal = da.GetValue(0).ToString();
                }
                con.Close();
            }
            int a1 = Int32.Parse(bal);
            int a2 = Int32.Parse(widr);
            if(a1 - a2 > 500)
            {
                string res = SubTwoStrings(bal, widr);

                MessageBox.Show("Withdraw Successfull!");

                con = new MySqlConnection(AppSettings.ConnectionString());

                con.Open();
                cmd = new MySqlCommand("update account set balance ='" + res + "' where Accountno='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                
                con.Close();

                // transactionss............

                con = new MySqlConnection(AppSettings.ConnectionString());

                con.Open();


                string query = "insert into transaction(Accountno , Date , Balance , Deposit , Withdraw) values (@ac ,@dat,@bal,@dep,@with )";
                cmd = new MySqlCommand(query, con);

                cmd.Parameters.Add("@ac", MySqlDbType.VarChar, 100);
                cmd.Parameters.Add("@dat", MySqlDbType.Date);
                cmd.Parameters.Add("@bal", MySqlDbType.Int32);
                cmd.Parameters.Add("@dep", MySqlDbType.Int32);
                cmd.Parameters.Add("@with", MySqlDbType.Int32);

                cmd.Parameters["@ac"].Value = textBox1.Text;
                cmd.Parameters["@dat"].Value = dateTimePicker1.Value;
                cmd.Parameters["@bal"].Value = Int32.Parse(res);
                cmd.Parameters["@dep"].Value = 0;
                cmd.Parameters["@with"].Value = Int32.Parse(textBox3.Text);
                cmd.ExecuteNonQuery();
                textBox3.Text = "";
                con.Close();

            }
            else
            {
                MessageBox.Show("Insufficient Balance for Withdraw!");
            }
            
        }
    }
}
