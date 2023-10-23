using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;


namespace car_rent
{
    public partial class carreturn : Form
    {
        public carreturn()
        {
            InitializeComponent();
            fillcom();           

        }

        void fillcom()
        {

            string constring = "server=HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True;";
            string Query = "select * from rent";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myreader;
            try
            {

                conDataBase.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString(1);


                    kryptonTextBox1.Items.Add(sName);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";

            SqlConnection sqlconnect_search = new SqlConnection(sqlpath);
            string search = "select * from rent where surname ='" + kryptonTextBox1.Text.ToString().ToUpper() + "'";
            SqlCommand sql_search = new SqlCommand(search, sqlconnect_search);
            sqlconnect_search.Open();
            
                SqlDataReader sqlReader = default(SqlDataReader);
                sqlReader = sql_search.ExecuteReader();
                while (sqlReader.HasRows)
                {
                    if (sqlReader.Read())
                    {
                        kryptonTextBox2.Text = (string)(sqlReader["surname"].ToString());
                        kryptonTextBox3.Text = (string)(sqlReader["othernames"].ToString());
                        kryptonTextBox4.Text = (string)(sqlReader["phone"].ToString());
                        kryptonTextBox5.Text = (string)(sqlReader["gender"].ToString());
                        kryptonTextBox6.Text = (string)(sqlReader["DOB"].ToString());
                        kryptonTextBox7.Text = (string)(sqlReader["nationalcard"].ToString());
                        kryptonTextBox8.Text = (string)(sqlReader["state"].ToString());
                        kryptonTextBox9.Text = (string)(sqlReader["lga"].ToString());
                        kryptonTextBox18.Text = (string)(sqlReader["address"].ToString());

                        kryptonTextBox10.Text = (string)(sqlReader["vmodel"].ToString());
                        kryptonTextBox11.Text = (string)(sqlReader["vproduct"].ToString());
                        kryptonTextBox12.Text = (string)(sqlReader["vname"].ToString());
                        kryptonTextBox13.Text = (string)(sqlReader["vmaker"].ToString());
                        kryptonTextBox14.Text = (string)(sqlReader["plateno"].ToString());
                        kryptonTextBox15.Text = (string)(sqlReader["vcolor"].ToString());
                        kryptonTextBox16.Text = (string)(sqlReader["date_rent"].ToString());
                        kryptonTextBox17.Text = (string)(sqlReader["date_return"].ToString());
                        break;

                        //byte[] pic = (byte[])(sqlReader["pic"]);
                        //System.IO.MemoryStream loadPic = new System.IO.MemoryStream(pic);
                        //pictureBox1.Image = Image.FromStream(loadPic);
                        //break;
                    }
                    //else
                    //{
                    //MessageBox.Show("No Such record in the data base", "Customer Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                    ////   //// MessageBox.Show("No Such record in the data base",MessageBoxIcon.Information);
                    //}
                }
                sqlconnect_search.Close();
            }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
             string sqlpath = "server = HAYKAY470-PC\\PELUMI;Initial Catalog=car;Integrated Security=True";
                //making the sql connection by creating an object of the sqlconnection class
                SqlConnection sqlconnect = new SqlConnection(sqlpath);

                string command = "insert into carreturn(surname, othernames,phone,gender,DOB,nationalcard,state,lga,address,vmodel,vproduct,vname,vmaker,plateno,vcolor,date_rent,date_return,returned)";
                command = command + "values(@surname, @othernames@,@phone,@gender,@DOB,@nationalcard,@state,@lga,@address,@vmodel,@vproduct,@vname,@vmaker,@plateno,@vcolor,@date_rent,@date_return,@returned)";

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

                sql_insert_command.Parameters.AddWithValue("@vmodel", kryptonTextBox10.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vproduct", kryptonTextBox11.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vname", kryptonTextBox12.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vmaker", kryptonTextBox13.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@plateno", kryptonTextBox14.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@vcolor", kryptonTextBox15.Text.ToString());
                  sql_insert_command.Parameters.AddWithValue("@date_rent", kryptonTextBox16.Text.ToString());
                sql_insert_command.Parameters.AddWithValue("@date_return", kryptonTextBox17.Text.ToString());
                    sql_insert_command.Parameters.AddWithValue("returned", kryptonDateTimePicker1.Value.ToString());

                     sql_insert_command.ExecuteNonQuery();
 
                
               
                    MessageBox.Show("Car return successfully", "Car return  Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlconnect.Close();

               

            }

        private void carreturn_Load(object sender, EventArgs e)
        {

        }



           }
    }

