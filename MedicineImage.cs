using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PharmacyManagementystem
{
    public partial class MedicineImage : Form
    {


        public MedicineImage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashborad_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            this.Hide();
            Obj.Show();
        }

        private void btnManufacture_Click(object sender, EventArgs e)
        {
            Manufactuer Obj = new Manufactuer();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Manufactuer Obj = new Manufactuer();
            this.Hide();
            Obj.Show();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Medicine Obj = new Medicine();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Medicine Obj = new Medicine();
            this.Hide();
            Obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            this.Hide();
            Obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Seller Obj = new Seller();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Seller Obj = new Seller();
            this.Hide();
            Obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
            this.Hide();
            Obj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void MedicineImage_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"C:\Users\User\Desktop\project\Durgs Images");
            DataTable table = new DataTable();
            table.Columns.Add("File Name");

            for (int  i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                table.Rows.Add(file.Name);

            }
            dataGridView1.DataSource = table;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            MedicineImage myForm = new MedicineImage();
            String imageName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Image img;
            img = Image.FromFile(@"C: \Users\User\Desktop\project\Durgs Images"+imageName);
            myForm.pictureBox2.Image = img;
            myForm.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
