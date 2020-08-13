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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        DataTable Data;

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Shawon: 01676929932" +  "\nAshraf : 01679252176"  +  "\nAfsana: 0168747611 " + "\nNafisa: 01626030157" ); 
            string connectionString = @"server = SHAWON\SQLEXPRESS;database = bus; integrated security = sspi;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Aboutt", connection);
            Data = new DataTable();
            sda.Fill(Data);
            dataGridView1.DataSource = Data;
            connection.Close();


        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDIParent1 ss = new MDIParent1();
            ss.ShowDialog();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want To Close The Program?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
