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
    public partial class Medicine : Form
    {
        public Medicine()
        {
            InitializeComponent();
            ShowMedicine();
            GetManufactuer();
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
        private void Reset()
        {
            txtMedicineName.Text = "";
            txtMedicineType.SelectedIndex = 0;
            txtQuanity.Text = "";
            txtPrice.Text = "";
            txtManufactuerName.Text = "";
            Key = 0;
        }
        private void GetManufactuer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select ManufactuerId from ManufactuerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ManufactuerId", typeof(int));
            dt.Load(Rdr);
            txtManufactuerID.ValueMember = "ManufactuerId";
            txtManufactuerID.DataSource = dt;
            Con.Close();
        }
        private void GetManufactuerName()
        {
            Con.Open();
            string Query = "Select * from ManufactuerTbl where ManufactuerId='" + txtManufactuerID.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtManufactuerName.Text = dr["ManufactuerName"].ToString();
            }
            Con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "" || txtMedicineType.SelectedIndex == -1 || txtQuanity.Text == "" || txtQuanity.Text == "" || txtManufactuerID.SelectedIndex == -1 || txtManufactuerName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into MedicineTbl(MedicineName,MedicineType,MedicineQnty,MedicinePrice,MedicineManuId,MedicineManufecturer)values(@MN,@MT,@MQ,@MP,@MMI,@MM)", Con);
                    cmd.Parameters.AddWithValue("@MN", txtMedicineName.Text);
                    cmd.Parameters.AddWithValue("@MT", txtMedicineType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", txtQuanity.Text);
                    cmd.Parameters.AddWithValue("@MP", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@MMI", txtManufactuerID.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MM", txtManufactuerName.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Added Successfully");
                    Con.Close();
                    ShowMedicine();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtManufactuerID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetManufactuerName();
        }

        private void DGVMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicineName.Text = DGVMedicine.SelectedRows[0].Cells[1].Value.ToString();
            txtMedicineType.SelectedItem = DGVMedicine.SelectedRows[0].Cells[2].Value.ToString();
            txtQuanity.Text = DGVMedicine.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = DGVMedicine.SelectedRows[0].Cells[4].Value.ToString();
            txtManufactuerID.SelectedValue = DGVMedicine.SelectedRows[0].Cells[5].Value.ToString();
            txtManufactuerName.Text = DGVMedicine.SelectedRows[0].Cells[6].Value.ToString();
            if (txtMedicineName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVMedicine.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Medicine");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from MedicineTbl where MedicineId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Deleted Successfully");
                    Con.Close();
                    ShowMedicine();
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
            if (txtMedicineName.Text == "" || txtMedicineType.SelectedIndex == -1 || txtQuanity.Text == "" || txtQuanity.Text == "" || txtManufactuerID.SelectedIndex == -1 || txtManufactuerName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update MedicineTbl Set MedicineName=@MN,MedicineType=@MT,MedicineQnty=@MQ,MedicinePrice=@MP,MedicineManuId=@MMI,MedicineManufactuer=@MM where MedicineId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", txtMedicineName.Text);
                    cmd.Parameters.AddWithValue("@MT", txtMedicineType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", txtQuanity.Text);
                    cmd.Parameters.AddWithValue("@MP", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@MMI", txtManufactuerID.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MM", txtManufactuerName.Text);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Updated Successfully");
                    Con.Close();
                    ShowMedicine();
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
