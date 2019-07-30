using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Admistration_System
{
    public partial class Faculty_homepage : Form
    {
        String s1;
        //passing faculty id
        public Faculty_homepage()
        {
            InitializeComponent();
        }
        public Faculty_homepage(String s)
        {
            s1 = s;
            InitializeComponent();
        }
        //logout
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        //course details button
        private void button2_Click(object sender, EventArgs e)
        {
            COURSE_DETAILS cd = new COURSE_DETAILS(s1);
            cd.Show();
            this.Hide();
        }
        //personal details
        private void button1_Click(object sender, EventArgs e)
        {
            FAC_PD fpd = new FAC_PD(s1);
            fpd.Show();
            this.Hide();
        }

        private void Faculty_homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
