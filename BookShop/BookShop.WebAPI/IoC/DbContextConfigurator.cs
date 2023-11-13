using BookShop.DataAccess;
using BookShop.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace BookShop.WebAPI.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, BookShopSettings settings)
        {
            services.AddDbContextFactory<BookShopDbContext>(
                options => { options.UseSqlServer(settings.BookShopDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BookShopDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
