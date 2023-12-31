﻿using BookShop.BL.Admins.Entities;
using BookShop.DataAccess.Entities;
using BookShop.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Admins
{
    public class AdminsManager : IAdminsManager
    {
        private readonly IRepository<AdminEntity> _adminsRepository;
        private readonly IMapper _mapper;
        public AdminsManager(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminsRepository = adminsRepository;
            _mapper = mapper;
        }

        public AdminModel CreateAdmin(CreateAdminModel model)
        {
            var entity = _mapper.Map<AdminEntity>(model);

            _adminsRepository.Save(entity); 

            return _mapper.Map<AdminModel>(entity);
        }
        public void DeleteAdmin(Guid id)
        {
            var entity = _adminsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Admin not found");
            _adminsRepository.Delete(entity);
        }
        public AdminModel UpdateAdmin(Guid id, UpdateAdminModel model)
        {
            var entity = _adminsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Admin not found");
            entity.PasswordHash = model.PasswordHash;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Email = model.Email;
            _adminsRepository.Save(entity);
            return _mapper.Map<AdminModel>(entity);
        }

    }
}
