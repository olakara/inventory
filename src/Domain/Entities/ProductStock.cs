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
    ///  Product class represents a product in the inventory.
    /// </summary>
    public class ProductStock : BaseAuditableEntity
    {
        public Guid ProductId  { get; set; }
        public Product Product { get; set; }
        public ProductStatus Status { get; set; }        
    }
}
