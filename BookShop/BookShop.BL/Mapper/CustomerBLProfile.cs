using AutoMapper;
using BookShop.BL.Customers.Entities;
using BookShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Mapper
{
    public class CustomerBLProfile : Profile
    {
        public CustomerBLProfile()
        {
            CreateMap<AdminEntity, CustomerModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateCustomerModel, CustomerEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
