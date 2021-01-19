using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product>Products { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
