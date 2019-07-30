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
    public partial class FAC_PD : Form
    {
        public FAC_PD()
        {
            InitializeComponent();
        }
        String s1;
        //passing faulty id
        public FAC_PD(String s)
        {
            s1 = s;
            InitializeComponent();
        }

        private void FAC_PD_Load(object sender, EventArgs e)
        {
            String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from faculty where id=" + s1;//loading details 

            comm.CommandType = CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            int i = 0;
            da.Fill(ds, "Tbl_faculty");
            DataTable dt = ds.Tables["Tbl_faculty"];
            int t = dt.Rows.Count;
            // MessageBox.Show(t.ToString());
            DataRow dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_faculty";
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //home button
        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_homepage fh = new Faculty_homepage(s1);
            fh.Show();
            this.Hide();
        }
        //logout button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
