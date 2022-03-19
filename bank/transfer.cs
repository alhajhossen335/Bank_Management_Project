using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace bank
{
    public partial class transfer : Form
    {
        public transfer()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main foo = new Main();
            foo.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_verify1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox1.Text != "")
            {
                string ss = "";
                cmd = new MySqlCommand("select Accountno from account where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ss = da.GetValue(0).ToString();
                }
                if(ss == textBox1.Text)
                {
                    MessageBox.Show("Valid Account!");
                } else
                {
                    MessageBox.Show("Invalid Account!");
                }
                con.Close();
            }
        }

        private void button_verify2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox2.Text != "")
            {
                string ss = "";
                cmd = new MySqlCommand("select Accountno from account where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", textBox2.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ss = da.GetValue(0).ToString();
                }
                if (ss == textBox2.Text)
                {
                    MessageBox.Show("Valid Account!");
                }
                else
                {
                    MessageBox.Show("Invalid Account!");
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox4.Text != "")
            {
                string ss = "";
                cmd = new MySqlCommand("select Balance from account where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ss = da.GetValue(0).ToString();
                }
                con.Close();
                int bal = Int32.Parse(ss);
                int amount = Int32.Parse(textBox4.Text);


                if(bal - amount > 500)
                {
                    transferring(textBox1.Text, textBox2.Text , amount);
                    MessageBox.Show("Balance Transferred!");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Insufficient Balance for Transfer!");
                }
                
            }
        }
        public void transferring(string from , string to ,int amount)
        {
            // Updating in to account
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;

            cmd = new MySqlCommand("select Balance from account where Accountno='" + to + "'", con);

            MySqlDataReader da = cmd.ExecuteReader();
            int bal = 0;
            string ss = "";
            while (da.Read())
            {
                ss = da.GetValue(0).ToString();
                //bal = da.GetValue(0);
            }
            bal = Int32.Parse(ss);
            con.Close();
            int res = amount + bal; 
            con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();
            cmd = new MySqlCommand("update account set balance ='" + res + "' where Accountno='" + to + "'", con);
            cmd.ExecuteNonQuery();
   
            con.Close();


            // Updating in from account

            con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            cmd = new MySqlCommand("select Balance from account where Accountno='" + from + "'", con);

            da = cmd.ExecuteReader();
            bal = 0;
            ss = "";
            while (da.Read())
            {
                ss = da.GetValue(0).ToString();
                //bal = da.GetValue(0);
            }
            bal = Int32.Parse(ss);
            con.Close();
            
            res =  bal - amount ;

            con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();
            cmd = new MySqlCommand("update account set balance ='" + res + "' where Accountno='" + from + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();

            // Transactions.............

            con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();


            string query = "insert into transfer(Fromaccount , Toaccount , Date , Amount) values (@fac ,@tac,@dat,@amo )";
            cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@fac", MySqlDbType.VarChar, 100);
            cmd.Parameters.Add("@tac", MySqlDbType.VarChar , 100);
            cmd.Parameters.Add("@dat", MySqlDbType.Date);
            cmd.Parameters.Add("@amo", MySqlDbType.Int32);
            //cmd.Parameters.Add("@with", MySqlDbType.Int32);

            cmd.Parameters["@fac"].Value = textBox1.Text;
            cmd.Parameters["@tac"].Value = textBox2.Text;
            cmd.Parameters["@dat"].Value = dateTimePicker1.Value;
            cmd.Parameters["@amo"].Value = amount;
            //md.Parameters["@with"].Value = Int32.Parse(textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
