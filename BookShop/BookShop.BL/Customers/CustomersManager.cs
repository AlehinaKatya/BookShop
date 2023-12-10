using BookShop.BL.Customers.Entities;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Customers
{
    public class CustomersManager : ICustomersManager
    {
        private readonly IRepository<CustomerEntity> _customersRepository;
        private readonly IMapper _mapper;
        public CustomersManager(IRepository<CustomerEntity> customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public CustomerModel CreateCustomer(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);

            _customersRepository.Save(entity);

            return _mapper.Map<CustomerModel>(entity);
        }
        public void DeleteCustomer(Guid id)
        {
            var entity = _customersRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Customer not found");
            _customersRepository.Delete(entity);
        }
        public CustomerModel UpdateCustomer(Guid id, UpdateCustomerModel model)
        {
            var entity = _customersRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException(" not found");
            entity.PasswordHash = model.PasswordHash;
            entity.Surname = model.Surname;
            entity.Email = model.Email;
            entity.Name = model.Name;
            entity.Patronymic = model.Patronymic;
            entity.PhoneNumber = model.PhoneNumber;
            _customersRepository.Save(entity);
            return _mapper.Map<CustomerModel>(entity);
        }

    }
}
