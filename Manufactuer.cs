using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PharmacyManagementystem
{
    public partial class Manufactuer : Form
    {
        public Manufactuer()
        {
            InitializeComponent();
            ShowManufactuer();
        }
        private SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\project\PharmacyManagementystem\PharmacyManagementystem\PharmacyDB.mdf;Integrated Security=True");

        public int Key { get; private set; }

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

        private void button7_Click(object sender, EventArgs e)
        {
            MedicineImage Obj = new MedicineImage();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MedicineImage Obj = new MedicineImage();
            this.Hide();
            Obj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }
        private void ShowManufactuer()
        {
            Con.Open();
            string Query = "Select * from ManufactuerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVManufctuer.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtManufactuerName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ManufactuerTbl(ManufactuerName,ManufactuerAddress,ManufactuerMobileNo,ManufactuerDate)values(@MN,@MA,@MMN,@MD)", Con);
                    cmd.Parameters.AddWithValue("@MN", txtManufactuerName.Text);
                    cmd.Parameters.AddWithValue("@MA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@MMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@MD", txtJoinDate.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacter Added Successfully");
                    Con.Close();
                    ShowManufactuer();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DGVManufctuer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtManufactuerName.Text = DGVManufctuer.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = DGVManufctuer.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text = DGVManufctuer.SelectedRows[0].Cells[3].Value.ToString();
            txtJoinDate.Text = DGVManufctuer.SelectedRows[0].Cells[4].Value.ToString();
            if (txtManufactuerName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVManufctuer.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Manufactuer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ManufactuerTbl where ManufactuerId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufactuer Deleted Successfully");
                    Con.Close();
                    ShowManufactuer();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Reset()
        {
            txtManufactuerName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            Key = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtManufactuerName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ManufactuerTbl Set ManufecturerName=@MN,ManufactuerAddress=@MA,ManufactuerMobileNo=@MMN,ManufactuerDate=@MD where ManufactuerId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", txtManufactuerName.Text);
                    cmd.Parameters.AddWithValue("@MA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@MMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@MD", txtJoinDate.Value.Date);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufactuer Updated Successfully");
                    Con.Close();
                    ShowManufactuer();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
