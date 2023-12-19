using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BookShop.DataAccess.Entities
{
    [Table("customers")]
    public class CustomerEntity : IdentityUser<int>, IBaseEntity
    {
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

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

    public class CustomerRoleEntity : IdentityRole<int>
    {
    }
}
