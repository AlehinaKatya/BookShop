using AutoMapper;
using BookShop.BL.Products.Entities;
using BookShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Mapper
{
    public class ProductBLProfile : Profile
    {
        public ProductBLProfile()
        {
            CreateMap<ProductEntity, ProductModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
                .ForMember(x => x.Status, y => y.MapFrom(src => src.Status));

            CreateMap<CreateProductModel, ProductEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Status, y => y.MapFrom(src => src.Status))
                .ForMember(x => x.ProductType, y => y.MapFrom(src => src.ProductType));
        }
    }
}
