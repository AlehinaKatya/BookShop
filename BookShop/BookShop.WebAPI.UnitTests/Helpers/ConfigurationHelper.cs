using Microsoft.Extensions.Configuration;

namespace BookShop.WebAPI.UnitTests.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }
    }
}
