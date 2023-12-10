using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Customers.Entities
{
    public class CreateCustomerModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
    }
}
