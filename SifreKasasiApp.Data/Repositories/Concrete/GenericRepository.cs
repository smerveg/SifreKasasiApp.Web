using SifreKasasiApp.Data.Context;
using SifreKasasiApp.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Data.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SifreKasasiAppContext context;

        public GenericRepository(SifreKasasiAppContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);

        }

        public void Delete(int id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }


        }

        public IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {

            context.Set<T>().Update(entity);

        }
    }
}
