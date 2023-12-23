using BookShop.WebAPI.Settings;

namespace BookShop.WebAPI.UnitTests.Helpers
{
    public static class TestSettingsHelper
    {
        public static BookShopSettings GetSettings()
        {
            return BookShopSettingsReader.Read(ConfigurationHelper.GetConfiguration());
        }
    }
}
