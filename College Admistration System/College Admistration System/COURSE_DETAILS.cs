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
    public partial class COURSE_DETAILS : Form
    {
        public COURSE_DETAILS()
        {
            InitializeComponent();
            String c;
        }
        String s1;
        //faculty id 
        public COURSE_DETAILS(String s)
        {
            s1 = s;
            InitializeComponent();
        }
        //home button
        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_homepage f1 = new Faculty_homepage(s1);
            f1.Show();
            this.Hide();
        }
        //logout button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String c = comboBox1.Text;

        }

        private void COURSE_DETAILS_Load(object sender, EventArgs e)
        {
            try
            {
                String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                //loading the courses faculty teches
                comm.CommandText = "select name from course where id in(select c_id from teaches where f_id =" + s1 + ")";
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_course");
                DataTable dt = ds.Tables["Tbl_course"];
                int t1 = dt.Rows.Count;
                //MessageBox.Show(t1.ToString());
                comboBox1.DataSource = dt.DefaultView;
                comboBox1.DisplayMember = "name";

                conn.Close();


            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid Details!");
            }
        }
        //passing course name and faculty id
        private void button3_Click(object sender, EventArgs e)
        {
            string c = comboBox1.Text;
            CD2 c2 = new CD2(c,s1);
            c2.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

