using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace College_Admistration_System
{
    public partial class Academics : Form
    {
        String s1;
        public Academics()
        {
            
            InitializeComponent();
        }
        //passing student id
        public Academics(String s)
        {
            s1 = s;
            InitializeComponent();
        }

        private void Academics_Load(object sender, EventArgs e)
        {
            String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from enroll where st_id=" + s1;//loading student academic details

            comm.CommandType = CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            int i = 0;
            da.Fill(ds, "Tbl_enroll");
            DataTable dt = ds.Tables["Tbl_enroll"];
            int t = dt.Rows.Count;
            DataRow dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_enroll";
            conn.Close();

            try
            {
                String oradc = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                OracleConnection conn2 = new OracleConnection(oradc);
                conn2.Open();
                OracleCommand comm2 = new OracleCommand();
                comm2.CommandText = "select c_id from enroll where st_id="+s1;//loading course id into combo box
                comm2.CommandType = CommandType.Text;
                DataSet ds2 = new DataSet();
                OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn2);
                da2.Fill(ds2, "Tbl_enroll");
                DataTable dt2 = ds2.Tables["Tbl_enroll"];
                int t2 = dt2.Rows.Count;
                comboBox1.DataSource = dt2.DefaultView;
                comboBox1.DisplayMember = "c_id";

                conn2.Close();


            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid Details!");
            }
        }
        //home button
        private void button4_Click(object sender, EventArgs e)
        {
            homepage h1 = new homepage(s1);
            h1.Show();
            this.Hide();
        }
        //logout button
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //total marks
        //procedure
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(oradb);
                //conn.Open();
                System.Data.OracleClient.OracleCommand comm = new System.Data.OracleClient.OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "tot_marks";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("s_id", System.Data.OracleClient.OracleType.Number).Value = s1;
                comm.Parameters.Add("co_id", System.Data.OracleClient.OracleType.Number).Value = comboBox1.Text;
                comm.Parameters.Add("cout", System.Data.OracleClient.OracleType.Number).Direction = ParameterDirection.Output;
                conn.Open();
                comm.ExecuteNonQuery();
                textBox1.Text =( comm.Parameters["cout"].Value).ToString();
                conn.Close();


            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid Details!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
