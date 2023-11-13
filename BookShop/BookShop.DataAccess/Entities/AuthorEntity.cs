using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("authors")]
    public class AuthorEntity : BaseEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductAuthorEntity> ProductsAuthors { get; set; }
    }
}
