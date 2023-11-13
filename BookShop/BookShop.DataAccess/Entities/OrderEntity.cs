using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    [Table("orders")]
    public class OrderEntity : BaseEntity
    {
        public int ShoppingBasketId { get; set; }
        public ShoppingBasketEntity ShoppingBasket { get; set; }

        public int PointOfDeliveryId { get; set; }
        public PointOfDeliveryEntity PointOfDelivery { get; set; }

        public int Status { get; set; }
    }
}
