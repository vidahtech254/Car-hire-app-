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
    public partial class viewvehicle : Form
    {
        public viewvehicle()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
            //making the sql connection by creating an object of the sqlconnection class
            SqlConnection sqlconnect = new SqlConnection(sqlpath);
            //code for student bio data
            string command = "select * from registration";
            //Dim sql_insert_command As SqlCommand = New SqlCommand(command, sqlconnect)
            SqlDataAdapter data = new SqlDataAdapter(command, sqlconnect);
            DataSet data1 = new DataSet();
            sqlconnect.Open();
            data.Fill(data1, "registration");
            sqlconnect.Close();
            kryptonDataGridView1.DataSource = data1;
            kryptonDataGridView1.DataMember = "registration";
        }
    }
}
