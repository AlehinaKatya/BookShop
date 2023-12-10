using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products.Entities
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Annotation { get; set; }

        public int PublishingHouseId { get; set; }
        public int LanguageId { get; set; }
        public int YearOfPublication { get; set; }
    }
}
