﻿using Entities;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Operations
{
    public interface IRepository<T>
    {
        void Create(T entity);
        IQueryable<T> GetAll();
        T Get(int id);
    }
    public class RepositoryContext<T> : IRepository<T> where T : class
    {
        private DataContext _dataContext;

        public RepositoryContext(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public void Create(T entity)
        {
            this._dataContext.Set<T>().Add(entity);
            this._dataContext.SaveChanges();
        }

        public T Get(int id)
        {
            return this._dataContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this._dataContext.Set<T>();
        }
    }
}
