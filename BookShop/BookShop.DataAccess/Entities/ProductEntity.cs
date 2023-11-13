using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BookShop.DataAccess.Entities
{
    public enum TypeOfProduct
    {
        PaperBook,
        EBook,
        AudioBook
    }

    public enum TypeOfCover
    {
        Hardcover, //твердый переплет
        Softcover // мягкий переплет
    }

    public enum StatusOfProduct
    {
        OnSale, // в продаже
        OutOfStock, // нет в продаже
        Pending, // ожидается
        PreOrder // предзаказ
    }

    [Table("products")]
    public class ProductEntity : BaseEntity
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public string Annotation { get; set; }

        public int PublishingHouseId { get; set; }
        public PublishingHouseEntity PublishingHouse { get; set; }

        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        public int ProductType { get; set; }
        public int CoverType { get; set; }
        public int YearOfPublication { get; set; }

        public virtual ICollection<ProductAuthorEntity> ProductsAuthors { get; set; }
        public virtual ICollection<CharacteristicEntity> Characteristics { get; set; }
        public virtual ICollection<ShoppingBasketEntity> ShoppingBaskets{ get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }
}
