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
    public partial class update : Form
    {
        String a1, a2, a3, a4;
        public update()
        {
            InitializeComponent();
        }
        String s1, c1,c2;
        //home button
        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_homepage fhp = new Faculty_homepage(s1);
            fhp.Show();
            this.Hide();
        }

        private void update_Load(object sender, EventArgs e)
        {

        }
        //logout button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        //attendence button
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("attendence");
            
        }
        //initialization
        public update(String s,String p,String a)
        {
            c2 = a;//course name
            s1 = s;//faculty name
            c1 = p;//student name
            InitializeComponent();
        }
        //updating
        private void button5_Click(object sender, EventArgs e)
        {
            a1 = comboBox1.Text;
            a2 = textBox1.Text;
            
            
                try
                {
                    
                    String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                    OracleConnection conn = new OracleConnection(oradb);
                    conn.Open();
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = conn;
                //updating marks or attendence
                    comm.CommandText = "update enroll set " +a1+ "="+a2+" where st_id in (select id from student where fname = '" + c1 + "') and c_id in (select id from course where name='" + c2 + "') ";
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Done");
                    conn.Close();


                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Invalid Details!");
                }
            
            
        }
        //marks button
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("s1marks");
            comboBox1.Items.Add("s2marks");
            comboBox1.Items.Add("imarks");
            comboBox1.Items.Add("emarks");

        }
    }
}
