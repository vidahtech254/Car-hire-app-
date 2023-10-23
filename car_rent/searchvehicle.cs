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
    public partial class searchvehicle : Form
    {
        public searchvehicle()
        {
            InitializeComponent();
            fillcom1();
        }



        void fillcom1()
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



                    kryptonDomainUpDown1.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {



            if (kryptonDomainUpDown1.Text == "")
            {
                MessageBox.Show("Please select car ", "Message", MessageBoxButtons.OK);
                kryptonDomainUpDown1.Focus();
            }
            else
            {



                string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";

                SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
                string search = "select * from registration where vname =\'" + kryptonDomainUpDown1.Text.ToString() + "\'";
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

                            kryptonTextBox7.Text = (string)(sqlReader["vmodel"].ToString());
                            kryptonTextBox2.Text = (string)(sqlReader["vproduct"].ToString());
                            kryptonTextBox3.Text = (string)(sqlReader["vname"].ToString());
                            kryptonTextBox4.Text = (string)(sqlReader["vmaker"].ToString());
                            kryptonTextBox5.Text = (string)(sqlReader["plate"].ToString());
                            kryptonTextBox6.Text = (string)(sqlReader["vcolor"].ToString());
                            kryptonComboBox1.Text = (string)(sqlReader["vdoor"].ToString());
                            kryptonComboBox3.Text = (string)(sqlReader["vrim"].ToString());

                            kryptonComboBox2.Text = (string)(sqlReader["vcategory"].ToString());

                            byte[] pic = (byte[])(sqlReader["pics"]);
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



















        }

       
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchvehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
