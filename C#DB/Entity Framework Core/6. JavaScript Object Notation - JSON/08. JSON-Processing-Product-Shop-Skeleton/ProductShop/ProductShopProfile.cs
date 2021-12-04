using AutoMapper;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();
            CreateMap<ProductsInputDto, Product>();
            CreateMap<CategotiesInputDto, Category>();
            CreateMap<CategoriesProductsInputDto, CategoryProduct>();
        }
    }
}
