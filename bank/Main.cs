using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Account account = new Create_Account();
            account.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            transfer trn = new transfer();
            this.Hide();
            trn.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Withdraw wdr = new Withdraw();
            this.Hide();
            wdr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deposit dps = new Deposit();
            this.Hide();
            dps.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 foo = new Form1();
            foo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loan ob = new loan();
            ob.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerInfo ob = new CustomerInfo();
            ob.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loandetalis ob = new loandetalis();
            ob.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
