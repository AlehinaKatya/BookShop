namespace BookShop.WebAPI.Settings
{
    public class BookShopSettingsReader
    {
        public static BookShopSettings Read(IConfiguration configuration)
        {
            return new BookShopSettings()
            {
                BookShopDbContextConnectionString = configuration.GetValue<string>("BookShopDbContext")
            };
        }
    }
}
