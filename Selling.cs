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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
            ShowMedicine();
            ShowBill();
            GetCustomer();
            lblSellerName.Text = Login.User;
        }

        private SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\project\PharmacyManagementystem\PharmacyManagementystem\PharmacyDB.mdf;Integrated Security=True");

        public object Key { get; private set; }

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
        private void GetCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustomerId from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId", typeof(int));
            dt.Load(Rdr);
            txtCustomerID.ValueMember = "CustomerId";
            txtCustomerID.DataSource = dt;
            Con.Close();
        }

        private void GetCustomerName()
        {
            Con.Open();
            string Query = "Select * from CustomerTbl where CustomerId='" + txtCustomerID.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtCustomerName.Text = dr["CustomerName"].ToString();
            }
            Con.Close();
        }
        private void UpdateQnty()
        {
            try
            {
                int NewQnty = Stock - Convert.ToInt32(txtQuantity.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update MedicineTbl Set MedicineQnty=@MQ where MedicineId=@MKey", Con);
                cmd.Parameters.AddWithValue("@MQ", NewQnty);
                cmd.Parameters.AddWithValue("@MKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Updated Successfully");
                Con.Close();
                ShowMedicine();
                //Reset();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

        }
        private void InsertBill()
        {
            if (txtCustomerName.Text == "")
            {

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl(SellerName,CustomerId,CustomerName,BillDate,BillAmount)values(@SN,@CI,@CN,@BD,@BA)", Con);
                    cmd.Parameters.AddWithValue("@SN", lblSellerName.Text);
                    cmd.Parameters.AddWithValue("@CI", txtCustomerID.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CN", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@BA", GrdTotal);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully");
                    Con.Close();
                    ShowBill();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void ShowBill()
        {
            Con.Open();
            string Query = "Select * from BillTbl where SellerName='" + lblSellerName.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVTransactions.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ShowMedicine()
        {
            Con.Open();
            string Query = "Select * from MedicineTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVMedicine.DataSource = ds.Tables[0];
            Con.Close();
        }

        int n = 0, GrdTotal = 0;

        private void btnAddtoBill_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || Convert.ToInt32(txtQuantity.Text) > Stock)
            {
                MessageBox.Show("Enter Correct Quantity");
            }
            else
            {
                int total = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtPrice.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(DGVBill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtMedicine.Text;
                newRow.Cells[2].Value = txtQuantity.Text;
                newRow.Cells[3].Value = txtPrice.Text;
                newRow.Cells[4].Value = total;
                DGVBill.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                GrdTotal.Text = "Rs " + GrdTotal;
                n++;
                UpdateQnty();
            }

        }
        int Key = 0, Stock;

        string MedName;
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Pacify Pharmacy", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID Medicine Price Quantity Total", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in DGVBill.Rows)
            {
                MedId = Convert.ToInt32(row.Cells["Column1"].Value);
                MedName = "" + row.Cells["Column2"].Value;
                MedPrice = Convert.ToInt32(row.Cells["Column3"].Value);
                MedQty = Convert.ToInt32(row.Cells["Column4"].Value);
                MedTot = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + MedId, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, Pos));
                e.Graphics.DrawString("" + MedName, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, Pos));
                e.Graphics.DrawString("" + MedPrice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(128, Pos));
                e.Graphics.DrawString("" + MedQty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, Pos));
                e.Graphics.DrawString("" + MedTot, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, Pos));
                Pos = Pos + 20;
            }
            e.Graphics.DrawString("Grand Total:Rs" + GrdTotal, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(50, Pos + 50));
            e.Graphics.DrawString("***********Pacify Pharmacy**********", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(10, Pos + 85));
            DGVBill.Rows.Clear();
            DGVBill.Refresh();
            Pos = 100;
            GrdTotal = 0;
            n = 0;
        }
        int Pos = 60;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (PrintPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
            InsertBill();
        }

        private void DGVMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicine.Text = DGVMedicine.SelectedRows[0].Cells[1].Value.ToString();
            //txtMedicineType.SelectedItem = DGVMedicineStock.SelectedRows[0].Cells[2].Value.ToString();
            Stock = Convert.ToInt32(DGVMedicine.SelectedRows[0].Cells[3].Value.ToString());
            txtPrice.Text = DGVMedicine.SelectedRows[0].Cells[4].Value.ToString();
            //txtManufecturer.SelectedValue = DGVMedicineStock.SelectedRows[0].Cells[5].Value.ToString();
            //txtManufecturerName.Text = DGVMedicineStock.SelectedRows[0].Cells[6].Value.ToString();
            if (txtMedicine.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVMedicine.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        int n = 0;
#pragma warning disable IDE0044 // Add readonly modifier
        int Key = 0, Stock;
#pragma warning restore IDE0044 // Add readonly modifier
        int MedId, MedPrice, MedQty, MedTot;
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            GetCustomerName();
        }

        

    }
}
