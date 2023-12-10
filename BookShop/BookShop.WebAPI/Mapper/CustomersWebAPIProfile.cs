using BookShop.WebAPI.Controllers.Entiteis;
using BookShop.WebAPI.Controllers.Entities;
using AutoMapper;
using BookShop.BL.Customers.Entities;

namespace BookShop.WebAPI.Mapper
{
    public class CustomersWebAPIProfile : Profile
    {
        public CustomersWebAPIProfile()
        {
            CreateMap<CustomersFilter, CustomerModelFilter>();
            CreateMap<CreateCustomerRequest, CreateCustomerModel>();
            CreateMap<UpdateCustomerRequest, UpdateCustomerModel>();
        }
    }
}
