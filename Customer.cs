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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            ShowCustomer();
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
        private void ShowCustomer()
        {
            Con.Open();
            string Query = "Select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVCustomer.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtGender.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CustomerName,CustomerAddress,CustomerMobileNo,CustomerDOB,CustomerGender)values(@CN,@CA,@CMN,@CD,@CG)", Con);
                    cmd.Parameters.AddWithValue("@CN", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@CA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@CD", txtDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@CG", txtGender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Successfully");
                    Con.Close();
                    ShowCustomer();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DGVCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerName.Text = DGVCustomer.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = DGVCustomer.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text = DGVCustomer.SelectedRows[0].Cells[3].Value.ToString();
            txtDOB.Text = DGVCustomer.SelectedRows[0].Cells[4].Value.ToString();
            txtGender.SelectedItem = DGVCustomer.SelectedRows[0].Cells[5].Value.ToString();
            if (txtCustomerName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVCustomer.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Customer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CustomerTbl where CustomerId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    Con.Close();
                    ShowCustomer();
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
            if (Key == 0)
            {
                MessageBox.Show("Select the Customer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CustomerTbl where CustomerId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    Con.Close();
                    ShowCustomer();
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
