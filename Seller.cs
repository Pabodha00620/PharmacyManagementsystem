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
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
            ShowSeller();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\project\PharmacyManagementystem\PharmacyManagementystem\PharmacyDB.mdf;Integrated Security=True");
        private object txtAddress;

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
        private void ShowSeller()
        {
            Con.Open();
            string Query = "Select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVSeller.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtSellerName.Text = "";
            txtAdress.Text = "";
            txtMobileNo.Text = "";
            txtGender.SelectedIndex = 0;
            txtPassword.Text = "";
            Key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSellerName.Text == "" || txtAdress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1 || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SellerTbl(SellerName,SellerAddress,SellerMobileNo,SellerDOB,SellerGender,SellerPassword)values(@SN,@SA,@SMN,@SD,@SG,@SP)", Con);
                    cmd.Parameters.AddWithValue("@SN", txtSellerName.Text);
                    cmd.Parameters.AddWithValue("@SA", txtAdress.Text);
                    cmd.Parameters.AddWithValue("@SMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@SD", txtDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SP", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Added Successfully");
                    Con.Close();
                    ShowSeller();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
      
        private void DGVSeller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSellerName.Text = DGVSeller.SelectedRows[0].Cells[1].Value.ToString();
            txtAdress.Text = DGVSeller.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text = DGVSeller.SelectedRows[0].Cells[3].Value.ToString();
            txtDOB.Text = DGVSeller.SelectedRows[0].Cells[4].Value.ToString();
            txtGender.SelectedItem = DGVSeller.SelectedRows[0].Cells[5].Value.ToString();
            txtPassword.Text = DGVSeller.SelectedRows[0].Cells[2].Value.ToString();
            if (txtSellerName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVSeller.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Seller");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SellerTbl where SellerId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully");
                    Con.Close();
                    ShowSeller();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSellerName.Text == "" || txtAdress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1 || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Sellertbl Set SellerName=@SN,SellerAddress=@SA,SellerMobileNo=@SMN,SellerDOB=@SD,SellerGender=@SG,SellerPassword=@SP where SellerId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", txtSellerName.Text);
                    cmd.Parameters.AddWithValue("@SA", txtAdress.Text);
                    cmd.Parameters.AddWithValue("@SMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@SD", txtDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SP", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated Successfully");
                    Con.Close();
                    ShowSeller();
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
