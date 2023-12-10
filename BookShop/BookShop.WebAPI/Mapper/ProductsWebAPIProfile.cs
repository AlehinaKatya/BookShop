using BookShop.WebAPI.Controllers.Entiteis;
using BookShop.WebAPI.Controllers.Entities;
using AutoMapper;
using BookShop.BL.Products.Entities;

namespace BookShop.WebAPI.Mapper
{
    public class ProductsWebAPIProfile : Profile
    {
        public ProductsWebAPIProfile()
        {
            CreateMap<ProductsFilter, ProductModelFilter>();
            CreateMap<CreateProductRequest, CreateProductModel>();
            CreateMap<UpdateProductRequest, UpdateProductModel>();
        }
    }
}
