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
    public partial class Achievements : Form
    {
        String s1;
        //passing student id
        public Achievements(String s)
        {
            s1 = s;
            InitializeComponent();
        }
        public Achievements()
        {
            InitializeComponent();
        }

        private void Achievements_Load(object sender, EventArgs e)
        {
            try
            {
                String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from achivements where st_id=" + s1;//loading student achivemenets

                comm.CommandType = CommandType.Text;


                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                int i = 0;
                da.Fill(ds, "Tbl_achivements");
                DataTable dt = ds.Tables["Tbl_achivements"];
                int t = dt.Rows.Count;
                DataRow dr = dt.Rows[i];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_achivements";
                conn.Close();
            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("No achivements!");
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
