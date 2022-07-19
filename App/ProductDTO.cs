using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class ProductDTO
    {
        public int ProductID;
        public string ProductName;
        public int SupplierID;
        public int CategoryID;
        public string QuantityPerUnit;
        public float UnitPrice;
        public int UnitsInSock;
        public int UnitsOnOrder;
        public int ReorderLevel;
        public bool Discountinued;
    }
}
