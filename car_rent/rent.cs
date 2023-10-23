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
    public partial class rent : Form
    {
        public rent()
        {
            InitializeComponent();
            fillcom1();
            fillcom();
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



                    kryptonTextBox1.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }





        void fillcom()
        {

            string constring = "server=HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";
            string Query = "select * from registration";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myreader;
            try
            {

                conDataBase.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString(3);



                    comboBox7.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        

        //void fillcom()
        //{

        //    string constring = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
        //    string Query = "select * from registration";
        //    SqlConnection conDataBase = new SqlConnection(constring);
        //    SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
        //    SqlDataReader myreader;
        //    try
        //    {

        //        conDataBase.Open();
        //        myreader = cmdDataBase.ExecuteReader();
        //        while (myreader.Read())
        //        {
        //            string sName = myreader.GetString(1);
        //            string sName1 = myreader.GetString(2);
        //            string sName2 = myreader.GetString(3);
        //            string sName3 = myreader.GetString(4);
        //            string sName4 = myreader.GetString(5);
        //            string sName5 = myreader.GetString(6);



        //            comboBox1.Items.Add(sName);
        //            comboBox2.Items.Add(sName1);
        //            comboBox3.Items.Add(sName2);
        //            comboBox4.Items.Add(sName3);
        //            comboBox5.Items.Add(sName4);
        //            comboBox6.Items.Add(sName5);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }

           



        //}


        private void kryptonButton1_Click(object sender, EventArgs e)
        {


            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";

            SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
            string search = "select surname,othernames,phone,gender, DOB,nationalcard, state,lga,address from customer where cid =\'" + kryptonTextBox1.Text.ToString().ToUpper() + "\'";
            SqlCommand sql_search = new SqlCommand(search, sqlconnect_search);
            sqlconnect_search.Open();

            SqlDataReader sqlReader = default(SqlDataReader);
            sqlReader = sql_search.ExecuteReader();
            while (sqlReader.HasRows)
            {
                if (sqlReader.Read())
                {
                    kryptonTextBox2.Text = (string)(sqlReader["surname"]);
                    kryptonTextBox3.Text = (string)(sqlReader["othernames"]);
                    kryptonTextBox4.Text = (string)(sqlReader["phone"]);
                    kryptonTextBox5.Text = (string)(sqlReader["gender"]);
                    kryptonTextBox6.Text = (string)(sqlReader["DOB"]);
                    kryptonTextBox7.Text = (string)(sqlReader["nationalcard"]);
                    kryptonTextBox8.Text = (string)(sqlReader["state"]);
                    kryptonTextBox9.Text = (string)(sqlReader["lga"]);
                    kryptonTextBox18.Text = (string)(sqlReader["address"]);

                    break;
                }
            }
            sqlconnect_search.Close();

        }

        

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            try
            {

                string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
                //making the sql connection by creating an object of the sqlconnection class
                SqlConnection sqlconnect = new SqlConnection(sqlpath);

                string command = "insert into rent(surname,othernames,phone,gender,DOB,nationalcard,state,lga,address,vmodel,vproduct,vname,vmaker,plateno,vcolor,date_rent,date_return,pic)";
                command = command + "values(@surname,@othernames@,@phone,@gender,@DOB,@nationalcard,@state,@lga,@address,@vmodel,@vproduct,@vname,@vmaker,@plateno,@vcolor,@date_rent,@date_return,@pic)";

                SqlCommand sql_insert_command = new SqlCommand(command, sqlconnect);
                sqlconnect.Open();

                sql_insert_command.Parameters.AddWithValue("@surname", kryptonTextBox2.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@othernames@", kryptonTextBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@phone", kryptonTextBox4.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@gender", kryptonTextBox5.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@DOB", kryptonTextBox6.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@nationalcard", kryptonTextBox7.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@state", kryptonTextBox8.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@lga", kryptonTextBox9.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@address", kryptonTextBox18.Text.ToString());


                //nationalcard

                sql_insert_command.Parameters.AddWithValue("@vmodel", comboBox1.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vproduct", comboBox2.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vname", comboBox3.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vmaker", comboBox4.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@plateno", comboBox5.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcolor", comboBox6.Text.ToString());

                sql_insert_command.Parameters.AddWithValue("@date_rent", kryptonDateTimePicker1.Value.ToString());
                sql_insert_command.Parameters.AddWithValue("@date_return", kryptonDateTimePicker2.Value.ToString());



                System.IO.FileStream fs = new System.IO.FileStream(kryptonTextBox16.Text.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                long y = fs.Length;
                byte[] img = null;
                System.IO.BinaryReader f = new System.IO.BinaryReader(fs);
                img = f.ReadBytes(Convert.ToInt32(fs.Length));
                sql_insert_command.Parameters.AddWithValue("@pic", img);
                int status = sql_insert_command.ExecuteNonQuery();
                if (status != 0)
                {
                    MessageBox.Show("Data Sucessful", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlconnect.Close();

                }

            }

            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }

        }


        private void kryptonButton4_Click(object sender, EventArgs e)
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
                kryptonTextBox16.Text = pictureUpload.FileName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.ImageLocation = kryptonTextBox16.Text;
                //PictureBox1.ImageLocation = txtPicturePath.Text;

            }
        }

        private void rent_Load(object sender, EventArgs e)
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
                string search = "select * from registration where vname =\'" + comboBox7.Text.ToString() + "\'";
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
                            comboBox5.Text = (string)(sqlReader["plate"].ToString());
                            comboBox6.Text = (string)(sqlReader["vcolor"].ToString());

             //               var filePath = sqlReader.GetString(0);
                             
                            byte[] pic = (byte[])(sqlReader["pics"]);
                            System.IO.MemoryStream loadPic = new System.IO.MemoryStream(pic);
                            pictureBox1.Image = Image.FromStream(loadPic);

                            //kryptonTextBox16.Text = Image;
                           
                     

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

