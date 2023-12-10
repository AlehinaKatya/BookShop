using BookShop.BL.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Customers
{
    public interface ICustomersManager
    {
        CustomerModel CreateCustomer(CreateCustomerModel model);
        void DeleteCustomer(Guid id);
        CustomerModel UpdateCustomer(Guid id, UpdateCustomerModel model);
    }
}
