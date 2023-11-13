using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("points_of_delivery")]
    public class PointOfDeliveryEntity : BaseEntity
    {
        public string Address { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
