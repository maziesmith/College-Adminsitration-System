using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace College_Admistration_System
{
    public partial class homepage : Form
    {
        String s1;
        //passing student id
        public homepage(String s)
        {
            s1 = s;
            InitializeComponent();
        }
        //logout
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        //personal details
        private void button2_Click(object sender, EventArgs e)
        {
            PD p1 = new PD(s1);
            p1.Show();
            this.Hide();
        }
        //notifications
        private void button3_Click(object sender, EventArgs e)
        {
            Noti n1 = new Noti(s1);
            n1.Show();
            this.Hide();
        }
        //academics
        private void button4_Click(object sender, EventArgs e)
        {
            Academics ac = new Academics(s1);
            ac.Show();
            this.Hide();
        }
        //achivements
        private void button5_Click(object sender, EventArgs e)
        {
            Achievements a = new Achievements(s1);
            a.Show();
            this.Hide();
        }

        private void homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
