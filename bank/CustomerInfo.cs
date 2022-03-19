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
    public partial class CustomerInfo : Form
    {
        string Query = "";
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main ob = new Main();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
            if (textBox1.Text != "")
            {
                cmd = new MySqlCommand("select customer.Firstname , customer.Lastname , customer.District " +
                    ", customer.Phone, customer.Email , account.Balance from account,customer where " +
                    "(account.Accountno=@ac and account.Customerid = customer.Customerid)", con);

                cmd.Parameters.AddWithValue("@ac", textBox1.Text);
                MySqlDataReader da = cmd.ExecuteReader();
                
                string Fname = "";
                string Lname = "";
                string Dis = "";
                string Ph = "";
                string Eml = "";
                string Bal = "";
                while (da.Read())
                {
                    Fname = da.GetValue(0).ToString();
                    Lname = da.GetValue(1).ToString();
                    Dis = da.GetValue(2).ToString();
                    Ph = da.GetValue(3).ToString();
                    Eml = da.GetValue(4).ToString();
                    Bal = da.GetValue(5).ToString();
                }
                con.Close();
                string nam = Fname + " " + Lname;
                textBox2.Text = nam;
                textBox3.Text = Dis;
                textBox4.Text = Ph;
                textBox5.Text = Eml;
                textBox9.Text = Bal;

                now(textBox1.Text);

                
            }
            else
            { 
                MessageBox.Show("invalid Account");
            }
        }
        private void now(string acc)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;
           
                cmd = new MySqlCommand("select Sum(Withdraw) , Sum(Deposit) from transaction where Accountno=@ac", con);
                cmd.Parameters.AddWithValue("@ac", acc);
                MySqlDataReader da = cmd.ExecuteReader();
            string with = "";
            string depo = "";
                while (da.Read())
                {
                    with = da.GetValue(0).ToString();
                    depo = da.GetValue(1).ToString();
                }
                con.Close();
            textBox6.Text = with;
            textBox7.Text = depo;


            con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();


            cmd = new MySqlCommand("select Loan_amount from Loan where Accountno=@ac", con);
            cmd.Parameters.AddWithValue("@ac", acc);
            da = cmd.ExecuteReader();
            string loan = "";
            while (da.Read())
            {
                loan = da.GetValue(0).ToString();
                //depo = da.GetValue(1).ToString();
            }
            con.Close();
            textBox8.Text = loan;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Query = "Select Date , Balance , Deposit , Withdraw from transaction where Accountno = '"+textBox1.Text+"' and Date between '"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"' and '"+dateTimePicker2.Value.ToString("yyyy/MM/dd")+"'";
            UpdateQuery();
        }
        private void UpdateQuery()
        {
            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());
            con.Open();
           MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtRecords = new DataTable();
            dtRecords.Load(sdr);
            dataGridView1.DataSource = dtRecords;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
            con.Close();

        }
    }
}
