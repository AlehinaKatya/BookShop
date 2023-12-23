using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.WebAPI.UnitTests
{
    public static class BookShopApiEndpoints
    {
        public const string AuthorizeCustomerEndpoint = "auth/login";
        public const string RegisterCustomerEndpoint = "auth/register";
        public const string GetAllAdminsEndpoint = "admins";
        public const string GetAllProductsEndpoint = "products";
    }
}
