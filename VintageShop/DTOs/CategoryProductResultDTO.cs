using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.DTOs
{
    public class CategoryProductResultDTO
    {   
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}
