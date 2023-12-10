using BookShop.BL.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Customers
{
    public interface ICustomersProvider
    {
        IEnumerable<CustomerModel> GetCustomers(CustomerModelFilter modelFilter = null);
        CustomerModel GetCustomerInfo(Guid id);
    }
}
