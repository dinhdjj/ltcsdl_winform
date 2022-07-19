using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class ProductBUS
    {
        private ProductDAL productDAL;

        public ProductBUS()
        {
            productDAL = new ProductDAL();
        }

        public void Update(ProductDTO product)
        {
            productDAL.Update(product);
        }
    }
}
