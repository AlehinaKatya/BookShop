namespace BookShop.WebAPI.Settings
{
    public class BookShopSettingsReader
    {
        public static BookShopSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new BookShopSettings();
        }
    }
}
