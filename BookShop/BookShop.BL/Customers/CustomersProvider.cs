﻿using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.BL.Customers.Entities;

namespace BookShop.BL.Customers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly IRepository<CustomerEntity> _customerRepository;
        private readonly IMapper _mapper;

        public CustomersProvider(IRepository<CustomerEntity> customersRepository, IMapper mapper)
        {
            _customerRepository = customersRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetCustomers(CustomerModelFilter modelFilter = null)
        {
            var surname = modelFilter.Surname;
            var phoneNumber = modelFilter.PhoneNumber;

            var customers = _customerRepository.GetAll(x =>
            (surname == null || surname == x.Surname) &&
            (phoneNumber == null || phoneNumber == x.PhoneNumber));


            return _mapper.Map<IEnumerable<CustomerModel>>(customers);
        }

        public CustomerModel GetCustomerInfo(Guid id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer is null)
                throw new ArgumentException("Customer not found.");

            return _mapper.Map<CustomerModel>(customer);
        }
    }
}
