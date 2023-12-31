﻿using BookShop.DataAccess.Entities;
using System.Linq.Expressions;

namespace BookShop.DataAccess
{
    public interface IRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T? GetById(int id);
        T? GetById(Guid id);
        T Save(T entity);
        void Delete(T entity);
    }
}
