using BookShop.DataAccess.Entities;

namespace BookShop.WebAPI.Controllers.Entities
{
    public class ProductsFilter
    {
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; }
        public string Status { get; set; }
        public int PublishingHouseId { get; set; }
        public int LanguageId { get; set; }
        public string ProductType { get; set; }
    }
}
