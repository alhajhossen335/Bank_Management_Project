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
    public partial class Create_Account : Form
    {
        public Create_Account()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;database=bank_management_system; username = root; password=;");


        public void Customer_id()
        {
            con.Open();
            string query = "select max(Customerid) from customer";
            MySqlCommand cmd = new MySqlCommand(query,con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if(val == "")
                {
                    label16.Text = "10000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    label16.Text = a.ToString();


                }
                con.Close();
            }

        }



        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Customerid, Firstname, Lastname, Roadno, Houseno, Thana, District, Phone, Date, Email, Accountno, Accounttype, Description, Balance;

            Customerid = label16.Text;
            Firstname = txtFirstname.Text;
            Lastname = txtLastname.Text;
            Roadno = txtRoadno.Text;
            Houseno = txtHouseno.Text;
            Thana = txtThana.Text;
            District = txtDistrict.Text;
            Phone = txtPhone.Text;
            Date = txtDate.Text;
            Email = txtEmail.Text;
            Accountno = txtAccountno.Text;
            Accounttype = txtAccounttype.Text;
            Description = txtDescription.Text;
            Balance = txtBalance.Text;

            // editing by mubin

            MySqlConnection con = new MySqlConnection(AppSettings.ConnectionString());

            con.Open();

            MySqlCommand cmd;

            cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO customer(Customerid , Firstname , Lastname , Roadno , Houseno , Thana , District , Phone , Date , Email) VALUES(@cus , @first , @last ,@road,@house,@than,@dis,@phon,@dat,@emal)";
            cmd.Parameters.AddWithValue("@cus", Customerid);
            cmd.Parameters.AddWithValue("@first", Firstname);
            cmd.Parameters.AddWithValue("@last", Lastname);
            cmd.Parameters.AddWithValue("@road", Roadno);
            cmd.Parameters.AddWithValue("@house", Houseno);
            cmd.Parameters.AddWithValue("@than", Thana);
            cmd.Parameters.AddWithValue("@dis", District);
            cmd.Parameters.AddWithValue("@phon", Phone);
            cmd.Parameters.AddWithValue("@dat", Date);
            cmd.Parameters.AddWithValue("@emal", Email);

            cmd.ExecuteNonQuery();

            //con.Close();

            // Customer table filled..........

            cmd.CommandText = "INSERT INTO account(Accountno , Customerid , Accounttype , Description , Balance ) VALUES(@acc , @cos , @actype , @des , @bal)";

            cmd.Parameters.AddWithValue("@acc", Accountno);
            cmd.Parameters.AddWithValue("@cos", Customerid);
            cmd.Parameters.AddWithValue("@actype", Accounttype);
            cmd.Parameters.AddWithValue("@des", Description);
            cmd.Parameters.AddWithValue("@bal", Balance) ;

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Created!!!");

            // editing by mubin





            /* 
             con.Open();
             MySqlCommand cmd = new MySqlCommand();
             MySqlTransaction transation;
             transation = con.BeginTransaction();

             cmd.Connection = con;
             cmd.Transaction = transation;

             try
             {
                 cmd.CommandText = "Insert into customer(Customerid,Firstname,Lastname,Roadno,Houseno,Thana,District,Phone,Date,Email)values('" + Customerid + "','" + Firstname + "','" + Lastname + "','" + Roadno + "','" + Houseno + "','" + Thana + "','" + District + "','" + Phone + "','" + Date + "','" + Email + "',) ";

                 cmd.ExecuteNonQuery();

                 cmd.CommandText = "Insert into account(Accountno,Accounttype,Description,Balance)values('" + Accountno + "','" + Accounttype + "','" + Description + "','" + Balance + "')";
                 cmd.ExecuteNonQuery();

                 transation.Commit();
                 MessageBox.Show("Record added.....");


             }
             catch(Exception ex)
             {
                 transation.Rollback();
                 MessageBox.Show(ex.ToString());



             }
             finally
             {
                 con.Close();

             }
             */



        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            //Customer_id();
        }

        private void Create_Account_Load(object sender, EventArgs e)
        {
            Customer_id(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            button2.BackColor = ColorTranslator.FromHtml("#ae4bc7");
            button4.BackColor = ColorTranslator.FromHtml("#471054");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            button4.BackColor = ColorTranslator.FromHtml("#ae4bc7");
            button2.BackColor = ColorTranslator.FromHtml("#471054"); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main foo = new Main();
            foo.Show();
        }
    }
}
