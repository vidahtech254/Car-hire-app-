using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace car_rent
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            carregistration a = new carregistration();
            a.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Customer b = new Customer();
            b.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            searchvehicle c = new searchvehicle();
            c.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            rent d = new rent();
            d.Show();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            carreturn e1 = new carreturn();
            e1.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            updatecustomer f = new updatecustomer();
            f.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            viewcustomer g = new viewcustomer();
            g.Show();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            viewvehicle h = new viewvehicle();
            h.Show();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            viewrent rent = new viewrent();
            rent.Show();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            viewreturn return1 = new viewreturn();
            return1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kryptonLabel1.Location = new Point(kryptonLabel1.Location.X + 1, kryptonLabel1.Location.Y );
   
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            kryptonLabel1.Location = new Point(kryptonLabel1.Location.X , kryptonLabel1.Location.Y - 3);
   
        }
    }
}
