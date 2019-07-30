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
    public partial class Noti : Form
    {
        public Noti()
        {
            InitializeComponent();
        }
        String s1;
        //passing student id
        public Noti(String s)
        {
            s1 = s;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Noti_Load(object sender, EventArgs e)
        {
            try { 
            String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from notification ";//loading notifications

            comm.CommandType = CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            int i = 0;
            da.Fill(ds, "Tbl_Student");
            DataTable dt = ds.Tables["Tbl_student"];
            int t = dt.Rows.Count;
            //MessageBox.Show(t.ToString());
            DataRow dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_Student";
            conn.Close();
        }
             catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Nope");
            }
        }
        //home button
        private void button2_Click(object sender, EventArgs e)
        {
              
            homepage h1 = new homepage(s1);
            h1.Show();
            this.Hide();
        }
        //logout button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
