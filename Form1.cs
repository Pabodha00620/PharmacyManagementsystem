using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int Startpoint = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Startpoint += 1;
            progressBar1.Value = Startpoint;
            Presenctage.Text = Startpoint + "%";
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Login Obj = new Login();
                this.Hide();
                Obj.Show();
            }
        }
    }
}
