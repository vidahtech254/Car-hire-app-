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
    public partial class updatecustomer : Form
    {
        public updatecustomer()
        {
            InitializeComponent();
            fillcom1();
        }

        void fillcom1()
        {

            string constring = "server=HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";
            string Query = "select * from customer";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myreader;
            try
            {

                conDataBase.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString(11);



                    kryptonTextBox11.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";

            SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
            string search = "select * from customer where cid =\'" + kryptonTextBox11.Text.ToString().ToUpper() + "\'";
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
                        kryptonTextBox1.Text = (string)(sqlReader["surname"].ToString());
                        kryptonTextBox2.Text = (string)(sqlReader["othernames"].ToString());
                        kryptonTextBox4.Text = (string)(sqlReader["phone"].ToString());
                        kryptonTextBox5.Text = (string)(sqlReader["gender"].ToString());
                        kryptonTextBox6.Text = (string)(sqlReader["DOB"].ToString());
                        kryptonTextBox7.Text = (string)(sqlReader["nationalcard"].ToString());
                        kryptonTextBox8.Text = (string)(sqlReader["state"].ToString());
                        kryptonTextBox9.Text = (string)(sqlReader["lga"].ToString());
                        kryptonTextBox3.Text = (string)(sqlReader["address"].ToString());
                        byte[] pic = (byte[])(sqlReader["pic"]);
                        System.IO.MemoryStream loadPic = new System.IO.MemoryStream(pic);
                        pictureBox1.Image = Image.FromStream(loadPic);
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {//Data Source=HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True
            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
            SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
            string update = "update customer set surname = @surname,othernames = @othernames@, phone = @phone,";
            update = update + "gender = @gender,DOB = @DOB,nationalcard = @nationalcard, state= @state,lga=@lga, address=@address,pic= @pic where cid=\'" + kryptonTextBox11.Text.ToString().ToUpper() + "\'";
            SqlCommand sql_update = new SqlCommand(update, sqlconnect_search);
            sqlconnect_search.Open();
            //Try
            sql_update.Parameters.AddWithValue("@surname", kryptonTextBox1.Text.ToString());
            sql_update.Parameters.AddWithValue("@othernames@", kryptonTextBox2.Text.ToString());
            sql_update.Parameters.AddWithValue("@phone", kryptonTextBox2.Text.ToString());


            sql_update.Parameters.AddWithValue("@gender", kryptonTextBox2.Text.ToString());

            sql_update.Parameters.AddWithValue("@DOB", kryptonTextBox2.Text.ToString());

            sql_update.Parameters.AddWithValue("@nationalcard", kryptonTextBox2.Text.ToString());

            sql_update.Parameters.AddWithValue("@state", kryptonTextBox2.Text.ToString());

            sql_update.Parameters.AddWithValue("@lga", kryptonTextBox2.Text.ToString());
            sql_update.Parameters.AddWithValue("@address", kryptonTextBox2.Text.ToString());
            //  sql_update.Parameters.AddWithValue("@pic", kryptonTextBox2.Text.ToString());




            System.IO.FileStream fs = new System.IO.FileStream(kryptonTextBox10.Text.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
            long y = fs.Length;
            byte[] img = null;
            System.IO.BinaryReader f = new System.IO.BinaryReader(fs);
            img = f.ReadBytes(Convert.ToInt32(fs.Length));
            sql_update.Parameters.AddWithValue("@pic", img);
            int status = sql_update.ExecuteNonQuery();
            if (status != 0)
            {
                MessageBox.Show("Data Sucessful", "Member Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //sqlconnect.Close();









                //int status = default(int);
                //status = sql_update.ExecuteNonQuery();
                //if (status != 0)
                //{
                //    MessageBox.Show("Update sucessfull", "Update status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //sqlconnect_search.Close();
                ////Catch ex As Exception
                sqlconnect_search.Close();

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
                kryptonTextBox10.Text = pictureUpload.FileName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.ImageLocation = kryptonTextBox8.Text;
                //PictureBox1.ImageLocation = txtPicturePath.Text;
            }
        }

        private void updatecustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
