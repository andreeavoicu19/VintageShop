using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime ProductDate { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
