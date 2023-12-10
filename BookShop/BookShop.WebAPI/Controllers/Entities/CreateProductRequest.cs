using BookShop.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WebAPI.Controllers.Entiteis
{
    public class CreateProductRequest
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int PublishingHouseId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
