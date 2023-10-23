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
    public partial class carregistration : Form
    {
        public carregistration()
        {
            InitializeComponent();
        }

        private void kryptonColorButton1_SelectedColorChanged(object sender, ComponentFactory.Krypton.Toolkit.ColorEventArgs e)
        {
            

                    //the sql server path addresst
			string sqlpath = "server = HAYKAY470-PC\\AKIN;Initial Catalog=car;Integrated Security=True";
			//making the sql connection by creating an object of the sqlconnection class
			SqlConnection sqlconnect = new SqlConnection(sqlpath);
			//sql insert statement for the member table
			//string dateOfBirth = "";
            string command = "insert into registration(vmodel,vproduct,vname,vmaker,plate,vcolor,vdoor,vrim,vcategory,pics)";
            command = command + "values(@vmodel,@vproduct,@vname,@vmaker,@plate,@vcolor,@vdoor,@vrim,@vcategory,@pics)";
			
			SqlCommand sql_insert_command = new SqlCommand(command, sqlconnect);
			sqlconnect.Open();
            try
            {
                sql_insert_command.Parameters.AddWithValue("@vmodel", kryptonTextBox1.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vproduct", kryptonTextBox2.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vname", kryptonTextBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vmaker", kryptonTextBox4.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@plate", kryptonTextBox5.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcolor", kryptonTextBox6.Text.ToString());

                sql_insert_command.Parameters.AddWithValue("@vdoor", kryptonComboBox1.SelectedItem.ToString());
                sql_insert_command.Parameters.AddWithValue("@vrim", kryptonComboBox2.SelectedItem.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcategory", kryptonComboBox3.SelectedItem.ToString());
                //sql_insert_command.Parameters.AddWithValue("@pics", cmbMaritalStatus.SelectedItem.ToString());
                //sql_insert_command.Parameters.AddWithValue("@dateOfBirth", cmbDay.SelectedItem.ToString() + "/" + cmbMonth.SelectedItem.ToString() + "/" + cmbYear.SelectedItem.ToString());
                //sql_insert_command.Parameters.AddWithValue("@school", txtSchool.Text.ToString());
                //sql_insert_command.Parameters.AddWithValue("@department", txtDepartment.Text.ToString());
                //sql_insert_command.Parameters.AddWithValue("@designation", cmbDesignation.SelectedItem.ToString());
                //sql_insert_command.Parameters.AddWithValue("@nextOfKinName", txtKinName.Text.ToString());
                //sql_insert_command.Parameters.AddWithValue("@nextOfKinAddress", txtKinAddress.Text.ToString());
                //sql_insert_command.Parameters.AddWithValue("@nextOfKinPhone", txtKinPhone.Text.ToString());
                //sql_insert_command.Parameters.AddWithValue("@nextOfKinRelationship", cmbRelationship.SelectedItem.ToString());
                System.IO.FileStream fs = new System.IO.FileStream(kryptonTextBox8.Text.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                long y = fs.Length;
                byte[] img = null;
                System.IO.BinaryReader f = new System.IO.BinaryReader(fs);
                img = f.ReadBytes(Convert.ToInt32(fs.Length));
                sql_insert_command.Parameters.AddWithValue("@pics", img);
                int status = sql_insert_command.ExecuteNonQuery();
                if (status != 0)
                {
                    MessageBox.Show("Data Sucessful", "Member Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlconnect.Close();
                }
                else
                {
                    MessageBox.Show("wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            }
              catch (Exception)
                     {
               
              }
				

                   
              
        
           
        }
        

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureUpload = new System.Windows.Forms.OpenFileDialog();
            pictureUpload.Title = "Picture Upload";
            pictureUpload.InitialDirectory = "C:\\";
            pictureUpload.CheckFileExists = true;
            pictureUpload.CheckPathExists = true;
            pictureUpload.Filter = "All Files|*.*|Bitmap Files (*)|*.bmp;*.gif;*.jpg;*.png";
            pictureUpload.FilterIndex = 2;
            pictureUpload.ShowReadOnly = true;
            if (pictureUpload.ShowDialog() == DialogResult.OK)
            {
                kryptonTextBox8.Text = pictureUpload.FileName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.ImageLocation = kryptonTextBox8.Text;
                //PictureBox1.ImageLocation = txtPicturePath.Text;
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {


//the sql server path addresst
            try
            {

                string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
                //making the sql connection by creating an object of the sqlconnection class
                SqlConnection sqlconnect = new SqlConnection(sqlpath);

                string command = "insert into registration(vmodel,vproduct,vname,vmaker,plate,vcolor,vdoor,vrim,vcategory,pics)";
                command = command + "values(@vmodel,@vproduct,@vname,@vmaker,@plate,@vcolor,@vdoor,@vrim,@vcategory,@pics)";

                SqlCommand sql_insert_command = new SqlCommand(command, sqlconnect);
                sqlconnect.Open();

                sql_insert_command.Parameters.AddWithValue("@vmodel", kryptonTextBox1.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vproduct", kryptonTextBox2.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vname", kryptonTextBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vmaker", kryptonTextBox4.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@plate", kryptonTextBox5.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcolor", kryptonTextBox6.Text.ToString());

                sql_insert_command.Parameters.AddWithValue("@vdoor", kryptonComboBox1.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vrim", kryptonComboBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcategory", kryptonComboBox2.Text.ToString());
               
                System.IO.FileStream fs = new System.IO.FileStream(kryptonTextBox8.Text.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                long y = fs.Length;
                byte[] img = null;
                System.IO.BinaryReader f = new System.IO.BinaryReader(fs);
                img = f.ReadBytes(Convert.ToInt32(fs.Length));
                sql_insert_command.Parameters.AddWithValue("@pics", img);
                int status = sql_insert_command.ExecuteNonQuery();
                if (status != 0)
                {
                    MessageBox.Show("Data Sucessful", "Member Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlconnect.Close();

                }

            }

            catch (Exception msg)

            {
                MessageBox.Show( msg.Message);
            }
        
        }

        private void kryptonColorButton2_SelectedColorChanged(object sender, ComponentFactory.Krypton.Toolkit.ColorEventArgs e)
        {

        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog pictureUpload = new System.Windows.Forms.OpenFileDialog();
            pictureUpload.Title = "Picture Upload";
            pictureUpload.InitialDirectory = "C:\\";
            pictureUpload.CheckFileExists = true;
            pictureUpload.CheckPathExists = true;
            pictureUpload.Filter = "All Files|*.*|Bitmap Files (*)|*.bmp;*.gif;*.jpg;*.png";
            pictureUpload.FilterIndex = 2;
            pictureUpload.ShowReadOnly = true;
            if (pictureUpload.ShowDialog() == DialogResult.OK)
            {
                kryptonTextBox8.Text = pictureUpload.FileName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.ImageLocation = kryptonTextBox8.Text;
                //PictureBox1.ImageLocation = txtPicturePath.Text;
            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
