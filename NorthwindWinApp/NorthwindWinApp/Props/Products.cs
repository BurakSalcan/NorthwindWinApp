using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWinApp.Props
{
    internal class Products
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public int UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public int UnitOnOrder { get; set; }

        public int ReOrderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
