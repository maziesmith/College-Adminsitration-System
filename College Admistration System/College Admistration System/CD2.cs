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
    public partial class CD2 : Form
    {
        public CD2()
        {
            InitializeComponent();
        }
        String c1,s1;
        //course name,faculty name
        public CD2(String p,String s)
        {
            c1 = p;
            s1 = s;
            InitializeComponent();
        }

        //home button
        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_homepage fhp = new Faculty_homepage(s1);
            fhp.Show();
            this.Hide();

        }
        //logout button
        private void button1_Click(object sender, EventArgs e)
        { 
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        

        private void CD2_Load(object sender, EventArgs e)
        {
            try
            {
                String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                //loading student names who is taking that course of that faculty
                comm.CommandText = "select fname from student where id in(select st_id from enroll  where c_id in (select id from course where name='"+c1+ "'))";
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_student");
                DataTable dt = ds.Tables["Tbl_student"];
                comboBox1.DataSource = dt.DefaultView;
                comboBox1.DisplayMember = "fname";

                conn.Close();


            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid Details!");
            }
        }
        //passing faculty id,course name , student name
        private void button3_Click(object sender, EventArgs e)
        {
            String c = comboBox1.Text;
            update u1 = new update(s1, c,c1);
            u1.Show();
            this.Hide();

        }
    }
}
