using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace App
{
    class ProductDAL
    {
        SqlConnection conn;

        private void connect()
        {
            string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            conn = new SqlConnection(connection);
        }

        public void Update(ProductDTO product)
        {
        }
    }
}
