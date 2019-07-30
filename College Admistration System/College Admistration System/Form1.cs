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
    public partial class Form1 : Form
    {
        String ID;
        String fname;
        String lname;
        String dob;
        String sex;
        String email;
        String contact;
        String fa_name;
        String address;
        String password;
        String p_c;
        String dept;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //On click of button register
        private void button2_Click(object sender, EventArgs e)
        {
            Registration r1 = new Registration();
            r1.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        int i = 0;
        //onclick of button login and validating
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="student")
            {
                try
                {
                    String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                    OracleConnection conn = new OracleConnection(oradb);
                    conn.Open();
                    OracleCommand comm = new OracleCommand();
                    comm.CommandText = "select * from student where id = " + textBox1.Text;
                    comm.CommandType = CommandType.Text;
                    DataSet ds = new DataSet();
                    OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "Tbl_student");
                    DataTable dt = ds.Tables["Tbl_student"];
                    int t1 = dt.Rows.Count;
                    DataRow dr = dt.Rows[i];
                    if (t1 != 0)
                    {
                        ID = dr["ID"].ToString();
                        fname = dr["FNAME"].ToString();
                        lname = dr["lNAME"].ToString();
                        dob = dr["dob"].ToString();
                        sex = dr["SEX"].ToString();
                        email = dr["EMAIL"].ToString();
                        contact = dr["contact_no"].ToString();
                        fa_name = dr["father_name"].ToString();
                        address = dr["Address"].ToString();
                        password = dr["password"].ToString();
                        p_c = dr["parent_contact"].ToString();


                        conn.Close();
                        //validating credintials
                        if(textBox1.Text==ID && textBox2.Text==password)
                        {
                            homepage hp = new homepage(textBox1.Text);
                            hp.Show();
                            this.Hide();
                        }
                        //wrong credintials
                        else
                        {
                            label5.Text = "wrong credentials!!";
                        }
                    }
                }

                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Invalid Details!");       
                }
            }
            else if(comboBox1.Text=="faculty")
            {
                try
                {
                    String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                    OracleConnection conn = new OracleConnection(oradb);
                    conn.Open();
                    OracleCommand comm = new OracleCommand();
                    comm.CommandText = "select * from faculty where id = " + textBox1.Text;
                    comm.CommandType = CommandType.Text;
                    DataSet ds = new DataSet();
                    OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "Tbl_faculty");
                    DataTable dt = ds.Tables["Tbl_faculty"];
                    int t2 = dt.Rows.Count;
                    DataRow dr = dt.Rows[i];
                    if (t2 != 0)
                    {
                        ID = dr["ID"].ToString();
                        fname = dr["FNAME"].ToString();
                        lname = dr["lNAME"].ToString();
                        dob = dr["dob"].ToString();
                        sex = dr["SEX"].ToString();
                        //email = dr["EMAIL"].ToString();
                        contact = dr["contact_no"].ToString();
                        dept = dr["dept"].ToString();
                        address = dr["Address"].ToString();
                        password = dr["password"].ToString();
                       // p_c = dr["parent_contact"].ToString();


                        conn.Close();

                        //validating credintials
                        if (textBox1.Text == ID && textBox2.Text == password)
                        {
                            Faculty_homepage fhp = new Faculty_homepage(textBox1.Text);
                            fhp.Show();
                            this.Hide();
                        }
                        //wrong credintials
                        else
                        {
                            label5.Text = "wrong credentials!!";
                        }
                    }
                }

                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Invalid Details!");
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("student");
            comboBox1.Items.Add("faculty");
        }
    }
}
