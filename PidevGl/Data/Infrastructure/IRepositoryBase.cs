﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> where);
        T GetById(long id);
        IEnumerable<T> GetALL();
        T GetById(string id);
        T GetById(int id, int PublicationId, string Description);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null,
            Expression<Func<T, bool>> orderBy = null);
        
    }
}
