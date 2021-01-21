using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VintageShop.DTOs;
using VintageShop.Models;

namespace VintageShop.Mapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAddDTO>().ReverseMap();
            CreateMap<Category, CategoryEditDTO>().ReverseMap();
            CreateMap<Category, CategoryResultDTO>().ReverseMap();
            CreateMap<Product, ProductAddDTO>().ReverseMap();
            CreateMap<Product, ProductEditDTO>().ReverseMap();
            CreateMap<Product, ProductResultDTO>().ReverseMap();
        }
    }
}
