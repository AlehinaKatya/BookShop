using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("reviews")]
    public class ReviewEntity : BaseEntity
    {
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public string Text { get; set; }
    }
}
