using BookShop.BL.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products
{
    public interface IProductsManager
    {
        ProductModel CreateProduct(CreateProductModel model);
        void DeleteProduct(Guid id);
        ProductModel UpdateProduct(Guid id, UpdateProductModel model);
    }
}
