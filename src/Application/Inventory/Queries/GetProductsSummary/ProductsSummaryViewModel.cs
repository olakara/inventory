using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Queries.GetProductsSummary
{
    public class ProductsSummaryViewModel
    {
        public int ProductsSold { get; set; }
        public int ProductsInStock { get; set; }
        public int ProductsDamaged { get; set; }
    }
}
