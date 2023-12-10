using BookShop.BL.Admins;
using BookShop.BL.Customers;
using BookShop.BL.Products;
using BookShop.DataAccess;

namespace BookShop.WebAPI.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAdminsProvider, AdminsProvider>();
            services.AddScoped<IAdminsManager, AdminsManager>();
            services.AddScoped<ICustomersProvider, CustomersProvider>();
            services.AddScoped<ICustomersManager, CustomersManager>();
            services.AddScoped<IProductsProvider, ProductsProvider>();
            services.AddScoped<IProductsManager, ProductsManager>();
        }
    }
}
