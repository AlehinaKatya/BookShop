namespace BookShop.WebAPI.Settings
{
    public class BookShopSettingsReader
    {
        public static BookShopSettings Read(IConfiguration configuration)
        {
            return new BookShopSettings()
            {
                BookShopDbContextConnectionString = configuration.GetValue<string>("BookShopDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret")
            };
        }
    }
}
