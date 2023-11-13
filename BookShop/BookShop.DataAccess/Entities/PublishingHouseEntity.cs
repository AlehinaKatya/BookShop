using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("publishing_houses")]
    public class PublishingHouseEntity : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
