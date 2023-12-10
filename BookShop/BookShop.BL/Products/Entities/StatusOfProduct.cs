using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Products.Entities
{
    public enum StatusOfProduct
    {
        OnSale, // в продаже
        OutOfStock, // нет в продаже
        Pending, // ожидается
        PreOrder // предзаказ
    }
}
