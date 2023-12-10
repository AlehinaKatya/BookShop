using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products.Entities
{
    public class UpdateProductModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Annotation { get; set; }
    }
}
