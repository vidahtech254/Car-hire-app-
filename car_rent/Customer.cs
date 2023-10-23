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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

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
                kryptonTextBox10.Text = pictureUpload.FileName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.ImageLocation = kryptonTextBox10.Text;
                //PictureBox1.ImageLocation = txtPicturePath.Text;
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            //the sql server path addresst
            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
            //making the sql connection by creating an object of the sqlconnection class
            SqlConnection sqlconnect = new SqlConnection(sqlpath);
            //sql insert statement for the member table
           // string dateOfBirth = "";
            string command = "insert into customer(surname,othernames,phone,gender,DOB,nationalcard,state,lga,address,pic)";
            command = command + "values(@surname,@othernames@,@phone,@gender,@DOB,@nationalcard,@state,@lga,@address,@pic)";

            SqlCommand sql_insert_command = new SqlCommand(command, sqlconnect);
            sqlconnect.Open();
            try
            {
                sql_insert_command.Parameters.AddWithValue("@surname", kryptonTextBox2.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@othernames@", kryptonTextBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@phone", kryptonTextBox4.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@gender", kryptonTextBox5.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@DOB", kryptonTextBox6.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@nationalcard", kryptonTextBox7.Text.ToString());         
                sql_insert_command.Parameters.AddWithValue("@state", kryptonTextBox8.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@lga", kryptonTextBox9.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@address", kryptonTextBox11.Text.ToString());
                System.IO.FileStream fs = new System.IO.FileStream(kryptonTextBox10.Text.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                long y = fs.Length;
                byte[] img = null;
                System.IO.BinaryReader f = new System.IO.BinaryReader(fs);
                img = f.ReadBytes(Convert.ToInt32(fs.Length));
                sql_insert_command.Parameters.AddWithValue("@pic", img);
                int status = sql_insert_command.ExecuteNonQuery();
                if (status != 0)
                {
                    MessageBox.Show("Data Sucessful", "Customer Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlconnect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Incomplete Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlconnect.Close();
            }
            int nu = default(int);
            string name = "CusP/NO/";
            SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
            string search = "select id from customer where phone =\'" + kryptonTextBox4.Text.ToString() + "\'";
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
                        name = name + sqlReader["id"];
                        kryptonTextBox1.Text = name;
                        nu = Convert.ToInt32(sqlReader["id"].ToString());
                        break;
                    }
                }
                sqlconnect_search.Close();
            }
            catch (Exception)
            {
                sqlconnect_search.Close();
            }
            SqlConnection con = new SqlConnection("server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True");
            string comm = "update customer set cid=@cid where id =" + nu.ToString();
            SqlCommand up = new SqlCommand(comm, con);
            con.Open();
            up.Parameters.AddWithValue("@cid", name);
            up.ExecuteNonQuery();
            con.Close();
        }

        
        }
    }

