using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Ticket_Management_System
{
    public partial class MDIParent1 : Form
    {
       

        public MDIParent1()
        {
            InitializeComponent();
            timer1.Start();
        }

      

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void seatBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seat_book ss = new Seat_book();
            //ss.MdiParent = this;
            ss.Show();
            this.Hide();

        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ss = new Login();
            ss.ShowDialog();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ss = new About();
            ss.Show();
            this.Hide();
        }

        private void acCoachToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.time_lbl.Text = datetime.ToString();
        }
    }
}
