using BookShop.BL.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products
{
    public interface IProductsProvider
    {
        IEnumerable<ProductModel> GetProducts(ProductModelFilter modelFilter = null);
        ProductModel GetProductInfo(Guid id);
    }
}
