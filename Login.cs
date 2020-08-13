using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bus_Ticket_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = @"server = SHAWON\SQLEXPRESS;database = bus; integrated security = sspi;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From Login where Username='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Successfully Logged In");
                this.Hide();
                MDIParent1 ss = new MDIParent1();
                ss.Show();

            }
            else
            {
                MessageBox.Show("Please Check your Username and password");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.time_lbl.Text = datetime.ToString();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want To Close The Program?", "Exit", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
