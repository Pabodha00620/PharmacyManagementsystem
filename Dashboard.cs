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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountMedicine();
            CountCustomer();
            CountSeller();
            SumAmount();
            GetSeller();
            SumAmountBySellers();
            GetBestCustomer();
            GetBestSeller();
        }
        private SqlConnection Con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\project\PharmacyManagementystem\PharmacyManagementystem\PharmacyDB.mdf;Integrated Security=True");

       

        private void lblBsetSeller_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnCustomer_Click(object sender, EventArgs e)
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

        private void btnSellers_Click(object sender, EventArgs e)
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

        private void btnSelling_Click(object sender, EventArgs e)
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

        private void btnMedicineImage_Click(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void CountMedicine()
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from MedicineTbl", Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblMedicines.Text = dt.Rows[0][0].ToString();
            Con1.Close();
        }
        private void CountCustomer()
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CustomerTbl", Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblCustomers.Text = dt.Rows[0][0].ToString();
            Con1.Close();
        }
        private void CountSeller()
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from SellerTbl", Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSellers.Text = dt.Rows[0][0].ToString();
            Con1.Close();
        }
        private void SumAmount()
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(BillAmount) from BillTbl", Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSellsBySeller.Text = "Rs " + dt.Rows[0][0].ToString();
            Con1.Close();
        }
        private void SumAmountBySellers()
        {
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(BillAmount) from BillTbl where SellerName='" + txtSellsBySeller.SelectedValue.ToString() + "'", Con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSellsBySeller.Text = "Rs " + dt.Rows[0][0].ToString();
            Con1.Close();
        }
        private void GetSeller()
        {
            Con1.Open();
            SqlCommand cmd = new SqlCommand("Select SellerName from SellerTbl", Con1);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SellerName", typeof(string));
            dt.Load(Rdr);
            txtSellsBySeller.ValueMember = "SellerName";
            txtSellsBySeller.DataSource = dt;
            Con1.Close();
        }
        private void GetBestCustomer()
        {
            try
            {
                Con1.Open();
                string InnerQuery = "select Max(BillAmount) from BillTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con1);
                sda1.Fill(dt1);
                string Query = "select CustomerName from BillTbl where BillAmount = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblBestCustomer.Text = dt.Rows[0][0].ToString();
                Con1.Close();

            }
            catch (Exception Ex)
            {
                Con1.Close();
            }

        }
        private void GetBestSeller()
        {
            try
            {
                Con1.Open();
                string InnerQuery = "select Max(BillAmount) from BillTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con1);
                sda1.Fill(dt1);
                string Query = "select SellerName from BillTbl where BillAmount = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblSellsBySeller.Text = dt.Rows[0][0].ToString();
                Con1.Close();

            }
            catch (Exception Ex)
            {
                Con1.Close();
            }

        }

        private void txtSellsBySeller_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SumAmountBySellers();
        }
    }
};
