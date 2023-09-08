﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Data.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter);
        T GetByFilter(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
