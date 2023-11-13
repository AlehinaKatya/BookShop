using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("customers")]
    public class CustomerEntity : BaseEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBith { get; set; }
        public int PersonalisedDiscount { get; set; }

        public virtual ICollection<ReviewEntity> Reviews {  get; set; }
        public virtual ICollection<ShoppingBasketEntity> ShoppingBaskets { get; set; }
    }
}
