using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookShop.WebAPI.Mapper;

namespace BookShop.BL.UnitTest.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(typeof(AdminsWebAPIProfile));
                x.AddProfile(typeof(CustomersWebAPIProfile));
                x.AddProfile(typeof(ProductsWebAPIProfile));
            });
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
