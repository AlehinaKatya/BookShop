namespace BookShop.WebAPI.Settings
{
    public class BookShopSettings
    {
        public string BookShopDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
