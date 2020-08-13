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
    public partial class Seat_book : Form
    {
        public Seat_book()
        {
            InitializeComponent();
            timer1.Start();
        }
         DataTable Data;
        string connectionString = @"server = Shawon\SQLEXPRESS;database = Ticketbook; integrated security = true;";
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Insert Into Booking  Values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox3.Text + "')", connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox3.Text = "";



            MessageBox.Show("Saved Succeessfully!!!!!!!!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter ("Update Booking Set Gender='" + comboBox1.Text + "',PhoneNumber='" + textBox2.Text + "',FromWhere='" + comboBox2.Text + "',Destination='" + comboBox3.Text  + "',Departure='" + comboBox4.Text + "',SeatNumber='" + comboBox5.Text  +  "' Where Name = '" + textBox1.Text + "'", connection);
            // SqlDataAdapter sda = new SqlDataAdapter(@"Update Books Set Name='" + textBox1.Text + "',PhoneNumber='" + textBox2.Text + "',From='" + comboBox3.Text + "',To='" + comboBox4.Text + "',Date'" + textBox5.Text + "',Deaparture='" + comboBox1.Text + "',SeatNumber='" + comboBox2.Text + "',Fare(TK)='" + textBox8.Text + "'", connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox3.Text = "";

            MessageBox.Show("Updated Succeessfully!!!!!!!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Delete From Booking Where Name='" + textBox1.Text + "'", connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Deleted Succeessfully!!!!!!!!");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Booking", connection);
             Data = new DataTable();
            sda.Fill(Data);
            dataGridView1.DataSource = Data;
            connection.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDIParent1 ss = new MDIParent1();
            ss.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            DataView Dv = Data.DefaultView;
            Dv.RowFilter = ""+comboBox6.Text + " LIKE '%" + textBox4.Text + "%'";
           dataGridView1.DataSource = Dv;
            //connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.time_lbl.Text = datetime.ToString();  
        }

        private void Seat_book_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Seat_book_Load(object sender, EventArgs e)
        {
            comboBox6.Items.Add("Name");
            comboBox6.Items.Add("FromWhere");
            comboBox6.Items.Add("Gender");
            comboBox6.Items.Add("Destination");
            comboBox6.Items.Add("SeatNumber");
        }
    }
}
