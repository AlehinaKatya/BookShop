using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DataAccess.Entities
{
    public enum StatusOfOrder
    {
        Adopted, // принят
        ReadyToShip, // готов к отправке
        OnTheWay, // в пути
        ReadyToIssue // готов к выдаче
    }
    [Table("orders")]
    public class OrderEntity : BaseEntity
    {
        public int ShoppingBasketId { get; set; }
        public ShoppingBasketEntity ShoppingBasket { get; set; }

        public int PointOfDeliveryId { get; set; }
        public PointOfDeliveryEntity PointOfDelivery { get; set; }

        public StatusOfOrder Status { get; set; }
    }
}
