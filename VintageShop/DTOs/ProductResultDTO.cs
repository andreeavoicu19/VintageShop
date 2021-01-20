using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.DTOs
{
    public class ProductResultDTO
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime ProductDate { get; set; }
    }
}
