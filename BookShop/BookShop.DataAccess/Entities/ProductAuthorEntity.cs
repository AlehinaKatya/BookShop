using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("product_author")]
    public class ProductAuthorEntity : BaseEntity
    {
        public int ProductId { get; set; }  
        public ProductEntity Product { get; set; }

        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
