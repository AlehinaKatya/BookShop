using BookShop.BL.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeCustomer(string email, string password);
        Task RegisterCustomer(string email, string password);
    }
}
