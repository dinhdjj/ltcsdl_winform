using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    class ProductDAL
    {
        SqlConnection conn;

        public ProductDAL()
        {
            connect();
        }

        private void connect()
        {
            string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            conn = new SqlConnection(connection);
        }

        public void Update(ProductDTO product)
        {
            try
            {
                string query = string.Format(
                    "update Products set ProductName=N'{0}', QuantityPerUnit=N'{1}', UnitPrice='{2}', CategoryID='{3}', SupplierID='{4}' where ProductID = '{5}'",
                    product.ProductName, product.QuantityPerUnit, product.UnitPrice, product.CategoryID, product.SupplierID, product.ProductID
                );
                SqlCommand com = new SqlCommand(query, conn);
                conn.Open();
                com.ExecuteNonQuery();
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
    }
}
