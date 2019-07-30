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
    public partial class Registration : Form
    {
        String s2;
        String ID1;
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
        public Registration()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
               
                String oradb1 = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
                OracleConnection conn1 = new OracleConnection(oradb1);
                conn1.Open();
                OracleCommand comm1 = new OracleCommand();
                comm1.Connection = conn1;
                String ss=null;
                //apply validations
                string m1 = textBox1.Text;//fnmae
                string m2 = textBox2.Text;//lname
                String m10 = textBox10.Text;//date
                String m3 = textBox3.Text;//contact number
                String m4 = textBox4.Text;//email
                string m5 = textBox5.Text;//parent name
                String m6 = textBox6.Text;//parent number
                String m7 = textBox7.Text;//address
                String m8 = textBox8.Text;//password
                //string str1 = "", str2 = "";
                int flag1 = 0, flag2 = 0, flag3 = 0, flag4=0, flag5=0,flag6=0,flag7=0,flag8=0,flag10=0,flagg=0;

                //Validating First name
                for (int i = 0; i < m1.Length; i++)
                {
                    if ((m1[i] >= 'a' && m1[i] <= 'z') || (m1[i] >= 'A' && m1[i] >= 'Z'))
                    {
                        continue;
                    }
                    else
                    {
                        flag1 = 1;
                        break;
                    }
                }
                if (m1 == "")
                {
                    flag1 = 1;
                }
                //validating last name
                for (int i = 0; i < m2.Length; i++)
                {
                    if ((m2[i] >= 'a' && m2[i] <= 'z') || (m2[i] >= 'A' && m2[i] >= 'Z'))
                    {
                        continue;
                    }
                    else
                    {
                        flag2 = 1;
                        break;
                    }
                }
                if (m2 == "")
                {
                    flag2 = 1;
                }
                //validating date of birth
                if (m10=="")
                {
                    flag10 = 1;
                }
                //validation for gender
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    flagg = 1;
                }
                //validating contact number
                int a1 = m3.Length;
                if(a1!=9)
                {
                    flag3 = 1;
                }

                try { 
                        int temp = Convert.ToInt32(textBox3.Text);
                }
                catch (Exception h)
                {
                    flag3 = 1;
                    MessageBox.Show("Please provide number only");
                }
        
                //validating email
                if (m4=="")
                {
                    flag4 = 1;
                }
                //valiadting parant name
                for (int i = 0; i < m5.Length; i++)
                {
                    if ((m5[i] >= 'a' && m5[i] <= 'z') || (m5[i] >= 'A' && m5[i] >= 'Z'))
                    {
                        continue;
                    }
                    else
                    {
                        flag5 = 1;
                        break;
                    }
                }
                if (m5 == "")
                {
                    flag5 = 1;
                }
                //validating parent number
                int a2= m6.Length;
                if (a2 != 9)
                {
                    flag6 = 1;
                }

                try
                {
                    int temp = Convert.ToInt32(textBox6.Text);
                }
                catch (Exception h)
                {
                    flag6 = 1;
                    MessageBox.Show("Please provide number only");
                }
                //validating password
                if (m8 == "")
                {
                    flag8 = 1;
                }
                //validatng address
                if (m7 == "")
                {
                    flag7 = 1;
                }
                

                //apply validations
                if (flag1 == 1)
                {
                    MessageBox.Show("Please Enter Your First Name\nNo numeric or special Characters allowed");
                }
                if (flag2 == 1)
                {
                    MessageBox.Show("Please Enter Your Last Name\nNo numeric or special Characters allowed");
                }
                if (flag10 == 1)
                {
                    MessageBox.Show("Please Enter Your Date of birth");
                }
                if (flagg == 1)
                {
                    MessageBox.Show("Please Enter Your Gender");
                }
                /*if (flag3 == 1)
                {
                    MessageBox.Show("Please Enter your number or Numeric Characters only");
                }*/
                if (flag4 == 1)
                {
                    MessageBox.Show("Please Enter Your email");
                }
                if (flag5 == 1)
                {
                    MessageBox.Show("Please Enter Your Parent Name\nNo numeric or special Characters allowed");
                }
                /*if (flag6 == 1)
                {
                    MessageBox.Show("Please Enter Your parent contact number \n only numbers ");
                }*/

                if (flag7 == 1)
                {
                    MessageBox.Show("Please enter Address");
                }
                if (flag8 == 1)
                {
                    MessageBox.Show("Please enter Password");
                }
                if(flag1==0 && flag2==0 && flag10==0 && flagg==0 && flag3==0 && flag4==0 && flag5==0 && flag6==0 && flag7==0 && flag8==0)
                {
                    //insertion using query
                    if (radioButton1.Checked)
                    {

                        ss = "Male";
                    }
                    else if (radioButton2.Checked)
                    {

                        ss = "Female";
                    }

                    comm1.CommandText = "insert into student values(" + label14.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox10.Text + "','" + ss + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                    comm1.CommandType = CommandType.Text;

                    comm1.ExecuteNonQuery();
                    conn1.Close();




                    Enroll_C ec = new Enroll_C(label14.Text);
                    ec.Show();
                    this.Hide();
                    MessageBox.Show("Registration sucessful\n");
                }


                //validations done

                
            }
            catch (OracleException ex)
            {
                MessageBox.Show("SQL Query Failed : " + ex.ToString());
                
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            String oradb = "Data Source=DESKTOP-K6AG53J;Persist Security Info=True;User ID=system;Password=student;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand comm = new OracleCommand();
            comm.CommandText = "select (max(id)+1) as id from  student";
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_student");
            DataTable dt = ds.Tables["Tbl_student"];
            int t = dt.Rows.Count;
            DataRow dr = dt.Rows[0];
            label14.Text= dr["id"].ToString();
            conn.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
