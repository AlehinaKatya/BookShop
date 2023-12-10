using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products.Entities
{
    public class ProductModelFilter
    {
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; }
        public string Status { get; set; }
        public int PublishingHouseId { get; set; }
        public int LanguageId { get; set; }
        public string ProductType { get; set; }
    }
}
