using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BookShop.DataAccess.Entities
{
    [Table("products")]
    public class ProductEntity : BaseEntity
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Annotation { get; set; }

        public int PublishingHouseId { get; set; }
        public PublishingHouseEntity PublishingHouse { get; set; }

        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        public string ProductType { get; set; }
        public int YearOfPublication { get; set; }

        public virtual ICollection<ProductAuthorEntity> ProductsAuthors { get; set; }
        public virtual ICollection<CharacteristicEntity> Characteristics { get; set; }
        public virtual ICollection<ShoppingBasketEntity> ShoppingBaskets{ get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }
}
