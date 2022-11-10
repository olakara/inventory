using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    ///  Product class represents a product and holds basic information about the product
    /// </summary>
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public ProductType  Type { get; set; }
        public Guid ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
