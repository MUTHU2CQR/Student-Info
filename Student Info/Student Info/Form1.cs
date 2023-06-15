using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Info
{
    public partial class Form1 : Form
    {
        string conn = "Server= DESKTOP-8H27944; Database= empdetails; Integrated Security = True;";
        private SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            populatedata();

        }
        private void populatedata()
        {

            SqlConnection con = new SqlConnection(conn);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from empDetails2", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textboxname.Text = "";
            textBoxage.Text = "";
            textBoxhobbies.Text = "";
            richTextBoxaddress.Text = "";
            dateTimePickerDOB.Text = "";
            textBoxFN.Text = "";
            textBoxMN.Text = "";
            textBoxTECSKILLS.Text = "";
            richTextBoxPROJECTS.Text = "";
            textBoxbscper.Text = "";
            textBoxhscper.Text = "";
            textBoxsslcper.Text = "";
            richTextBoxbscacdname.Text = "";
            richTextBoxhscacdname.Text = "";
            richTextBoxsslcacdname.Text = "";
            SUBMIT.Text = "";
            CLEAR.Text = "";
            radioButtonmale.Checked = true;
            radioButtonfemale.Checked = true;
            checkBoxfresher.Checked = true;
            checkBoxexperience.Checked = true;
            checkBoxexp0to1.Checked = true;
            checkBoxexp1to3.Checked = true;
            checkBoxexp3to5.Checked = true;
            // checkBoxexp5to7.Checked = false;

            populatedata();
        }

        private void SUBMIT_Click(object sender, EventArgs e)
        {
            string gender = "";
            string qualification = "";
            string workingexperience = "";
            string yearofexp = "";
            if (textboxname.Text == "")
            {
                MessageBox.Show("please enter your name", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (richTextBoxaddress.Text == "")
            {
                MessageBox.Show("please enter your address", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateTimePickerDOB.Text == "")
            {
                MessageBox.Show("please enter your DOB", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxage.Text == "")
            {
                MessageBox.Show("please enter your age", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxFN.Text == "")
            {
                MessageBox.Show("please enter your father name", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBoxMN.Text == "")
            {
                MessageBox.Show("please enter your mother name", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBoxTECSKILLS.Text == "")
            {
                MessageBox.Show("please enter your techinical skills", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (richTextBoxPROJECTS.Text == "")
            {
                MessageBox.Show("please enter your projects", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (radioButtonmale.Checked == true)
            {
                //  MessageBox.Show("please enter your gender","Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gender = "Male";
            }
            if (radioButtonfemale.Checked == true)
            {
                MessageBox.Show("please enter your gender", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gender = "Female";
            }
            if (textBoxbscper.Text != "")
            {
                qualification += "B.sc.,";
                qualification += textBoxbscper.Text;

            }
            if (richTextBoxbscacdname.Text != "")
            {
                qualification = richTextBoxbscacdname.Text;
            }

            if (textBoxhscper.Text != "")
            {
                // MessageBox.Show("please enter your hsc percentage", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                qualification += "HSC";
                qualification += textBoxhscper.Text;
            }
            if (richTextBoxhscacdname.Text != "")
            {
                qualification += richTextBoxhscacdname.Text;
            }
            if (textBoxsslcper.Text != "")
            {
                // MessageBox.Show("please enter your sslc percentage", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                qualification += "sslc";
                qualification += richTextBoxsslcacdname.Text;
            }
            if (richTextBoxsslcacdname.Text != "")
            {
                qualification += richTextBoxsslcacdname.Text;
            }
            if (textBoxhobbies.Text == "")
            {
                MessageBox.Show("please enter your hobbies", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (checkBoxfresher.Checked == true)
            {
                // MessageBox.Show("please enter your experience", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                workingexperience = "fresher";
            }
            if (checkBoxexperience.Checked == true)
            {
                // MessageBox.Show("please enter your experience", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                workingexperience = "experience";
            }
            if (checkBoxexp0to1.Checked == true)
            {
                //MessageBox.Show("please check your experience", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yearofexp = "0to1";
            }
            if (checkBoxexp1to3.Checked == true)
            {
                // MessageBox.Show("please check your experience", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yearofexp = "1to3";
            }
            if (checkBoxexp3to5.Checked == true)
            {
                //  MessageBox.Show("please check your experience", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yearofexp = "3to5";
            }
            
            {
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    DataTable dt = new DataTable();
                    string query1 = "insert into empdetails2 (name,address,age,dob,mothername,fathername,technincalskills,projects,gender,qualification,hobbies,workingexperience,yearofexp) values(' " + textboxname.Text + "','" + richTextBoxaddress.Text + "','" + textBoxage.Text + "','" + dateTimePickerDOB.Text + "','" + textBoxMN.Text + "','" + textBoxFN + "','" + textBoxTECSKILLS.Text + "','" + richTextBoxPROJECTS.Text + "','" + gender + "','" + qualification + "','" + textBoxhobbies.Text + "','" + workingexperience + "','" + yearofexp + " ')";
                    // string conn = "Server= DESKTOP-8H27944; Database= emp details; Integrated Security = True;";
                    SqlDataAdapter adapt = new SqlDataAdapter("select * from empDetails2", con);

                    try
                    {
                        con.Open();
                        cmd = new SqlCommand(query1, con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                        MessageBox.Show("emp details submitted successfully");
                        populatedata();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }
        private void checkBoxfresher_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}