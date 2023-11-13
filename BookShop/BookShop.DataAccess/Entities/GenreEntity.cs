using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("genres")]
    public class GenreEntity : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<CharacteristicEntity> Characteristics { get; set; }
    }
}
