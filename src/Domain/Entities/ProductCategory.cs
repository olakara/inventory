using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// ProductCategory represents the category in which multiple products can exists.
    /// </summary>
    public class ProductCategory : BaseAuditableEntity
    {
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
