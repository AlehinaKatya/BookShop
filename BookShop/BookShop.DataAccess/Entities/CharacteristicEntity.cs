using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("characteristics")]
    public class CharacteristicEntity : BaseEntity
    {
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
