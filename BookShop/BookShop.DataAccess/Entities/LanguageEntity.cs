using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("languages")]
    public class LanguageEntity : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
