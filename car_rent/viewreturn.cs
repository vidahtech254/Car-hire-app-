﻿using System;
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
    public partial class viewreturn : Form
    {
        public viewreturn()
        {
            InitializeComponent();
            fillcom();
        }
        void fillcom()
        {

            string constring = "server=HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";
            string Query = "select * from carreturn";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myreader;
            try
            {

                conDataBase.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString(12);



                    comboBox7.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
            ////making the sql connection by creating an object of the sqlconnection class
            //SqlConnection sqlconnect = new SqlConnection(sqlpath);
            ////code for student bio data
            //string command = "select * from carreturn";
            ////Dim sql_insert_command As SqlCommand = New SqlCommand(command, sqlconnect)
            //SqlDataAdapter data = new SqlDataAdapter(command, sqlconnect);
            //DataSet data1 = new DataSet();
            //sqlconnect.Open();
            //data.Fill(data1, "carreturn");
            //sqlconnect.Close();
            //kryptonDataGridView1.DataSource = data1;
            //kryptonDataGridView1.DataMember = "carreturn";
       
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void viewreturn_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox10_Click(object sender, EventArgs e)
        {



            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please select car ", "Message", MessageBoxButtons.OK);
                comboBox7.Focus();
            }
            else
            {



                string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";

                SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
                string search = "select * from carreturn where vname =\'" + comboBox7.Text.ToString() + "\'";
                SqlCommand sql_search = new SqlCommand(search, sqlconnect_search);
                sqlconnect_search.Open();
                try
                {

                    SqlDataReader sqlReader = default(SqlDataReader);
                    sqlReader = sql_search.ExecuteReader();
                    while (sqlReader.HasRows)
                    {
                        if (sqlReader.Read())
                        {


                            comboBox1.Text = (string)(sqlReader["vmodel"].ToString());
                            comboBox2.Text = (string)(sqlReader["vproduct"].ToString());
                            comboBox3.Text = (string)(sqlReader["vname"].ToString());
                            comboBox4.Text = (string)(sqlReader["vmaker"].ToString());
                            comboBox5.Text = (string)(sqlReader["plateno"].ToString());
                            comboBox6.Text = (string)(sqlReader["vcolor"].ToString());
                            textBox1.Text = (string)(sqlReader["date_rent"].ToString());
                            textBox2.Text = (string)(sqlReader["returned"].ToString());
                            break;
                        }
                    }
                    sqlconnect_search.Close();
                }
                catch (Exception)
                {
                    sqlconnect_search.Close();
                }




            }











        }
    }
}
