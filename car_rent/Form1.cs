using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace car_rent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try

            {
                //Data Source=HAYKAY470-PC\\AKIN;Initial Catalog=car;Integrated Security=True
                
                SqlConnection sqlconn = new SqlConnection("server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True");
                SqlCommand sqlcomm = new SqlCommand("select * from login where username =  '" + kryptonTextBox1.Text + "' and password = '" + kryptonTextBox2.Text + "'", sqlconn);
                sqlconn.Open();
                SqlDataReader reader;

                reader = sqlcomm.ExecuteReader();
                if (reader.Read())
                {


                    mainform akin = new mainform();
                    akin.ShowDialog();
                    

                }

                else
                {
                    MessageBox.Show("Invalid Authentication, Please check your login details and try again", "LOGIN ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sqlconn.Close();
            }
            catch (Exception sqlx)
            {
                MessageBox.Show("system error" + sqlx.Message, "database connection");

            }
        }

        }
    }

