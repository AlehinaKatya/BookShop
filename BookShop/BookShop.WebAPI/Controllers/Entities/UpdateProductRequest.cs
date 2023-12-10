using BookShop.DataAccess.Entities;

namespace BookShop.WebAPI.Controllers.Entiteis
{
    public class UpdateProductRequest
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Annotation { get; set; }
    }
}
