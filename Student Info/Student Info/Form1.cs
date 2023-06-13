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
        string conn = "Server= DESKTOP-8H27944; Database= emp details; Integrated Security = True;";
        public Form1()
        {
            InitializeComponent();
            

        }
        private void populatedata()
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                DataTable dt = new DataTable();
                var adapt = new SqlDataAdapter("select * from empDetails", conn);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            populatedata();
        }

        private class data
        {
        }
    }
}