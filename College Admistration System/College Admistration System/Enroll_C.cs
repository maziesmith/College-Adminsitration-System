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
    public partial class Enroll_C : Form
    {
        String sid;
        public Enroll_C(String s)
        {
            sid = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand comm = new OracleCommand();
                comm.Connection = conn;
                String ss = null;
                int t = 0;
                if (radioButton3.Checked)
                {
                    t = 101;
                    ss = "OOP";
                }
                else if (radioButton4.Checked)
                {
                    t = 102;
                    ss = "FAAD";
                }
                else if (radioButton5.Checked)
                {
                    t = 103;
                    ss = "SE";

                }
                else if (radioButton6.Checked)
                {
                    t = 104;
                    ss = "DS";
                }
                else if (radioButton7.Checked)
                {
                    t = 105;
                    ss = "FM";
                }
                else if (radioButton8.Checked)
                {
                    t = 106;
                    ss = "FD";
                }
                else if (radioButton9.Checked)
                {
                    t = 107;
                    ss = "ANP";
                }
                else if (radioButton10.Checked)
                {
                    t = 108;
                    ss = "MOS";
                }
                else if (radioButton11.Checked)
                {
                    t = 109;
                    ss = "MC";
                }
                else if (radioButton12.Checked)
                {
                    t = 110;
                    ss = "DSP";
                }
                else if (radioButton13.Checked)
                {
                    t = 111;
                    ss = "PC";
                }
                else if (radioButton14.Checked)
                {
                    t = 112;
                    ss = "OC";
                }
                String s_id = sid;
               comm.CommandText = "insert into enroll (st_id,c_id)  values('" + s_id+"','"+t+"')";
                comm.CommandType = CommandType.Text;

                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("SQL Query Failed : " + ex.ToString());
               // MessageBox.Show(age);
            }
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
