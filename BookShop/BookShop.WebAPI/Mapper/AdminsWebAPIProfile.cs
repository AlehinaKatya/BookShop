using AutoMapper;
using BookShop.BL.Admins.Entities;
using BookShop.WebAPI.Controllers.Entities;

namespace BookShop.WebAPI.Mapper
{
    public class AdminsWebAPIProfile : Profile
    {
        public AdminsWebAPIProfile()
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
