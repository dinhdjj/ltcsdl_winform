using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace App
{
    public partial class Form1 : Form
    {
        ProductBUS productBUS;

        public Form1()
        {
            InitializeComponent();

            productBUS = new ProductBUS();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            var product = new ProductDTO();
            product.ProductID = Int32.Parse(txtMaSP.Text);
            product.ProductName = txtTenSP.Text;
            product.QuantityPerUnit = txtSoLuong.Text;
            product.UnitPrice = Int32.Parse(txtDonGia.Text);
            product.CategoryID = Int32.Parse(cbLoaiSP.Text);
            product.SupplierID = Int32.Parse(cbNCC.Text);

            this.productBUS.Update(product);
        }

        #region Bien toan cuc
        SqlConnection conn;
        #endregion

        private void ketNoiDB()
        {
            string chuoiKN = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            conn = new SqlConnection(chuoiKN);

        }

        private DataTable LayDSSP()
        {
            DataTable dt = new DataTable();
            string query = "select ProductID, ProductName, UnitPrice, QuantityPerUnit, CategoryID, SupplierID  from Products";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private DataTable LayDSLSP()
        {
            DataTable dt = new DataTable();
            string query = "select CategoryID, CategoryName from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private DataTable LayDSNCC()
        {
            DataTable dt = new DataTable();
            string query = "select SupplierID, CompanyName from Suppliers";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            return dt;
        }

        private void themSP(string tenSP, double donGia, int maLSP, int maNCC)
        {
            try
            {
                string query = string.Format("insert into Products(ProductName, UnitPrice, CategoryID, SupplierID) values (N'{0}',{1},{2},{3})",
            tenSP, donGia, maLSP, maNCC);
                SqlCommand com = new SqlCommand(query, conn);
                conn.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Them Thanh cong");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketNoiDB();
            gvSanPham.DataSource = LayDSSP();

            // Loai san pham
            cbLoaiSP.DataSource = LayDSLSP();
            cbLoaiSP.DisplayMember = "CategoryName";
            cbLoaiSP.ValueMember = "CategoryID";

            // Nha Cung cap
            cbNCC.DataSource = LayDSNCC();
            cbNCC.DisplayMember = "CompanyName";
            cbNCC.ValueMember = "SupplierID";
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            themSP(txtTenSP.Text, Double.Parse(txtDonGia.Text), Int32.Parse(cbLoaiSP.SelectedValue.ToString()), Int32.Parse(cbNCC.SelectedValue.ToString()));
            gvSanPham.DataSource = LayDSSP();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
