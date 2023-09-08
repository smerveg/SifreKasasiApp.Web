using SifreKasasiApp.Data.Context;
using SifreKasasiApp.Data.Repositories.Abstract;
using SifreKasasiApp.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SifreKasasiAppContext context;

        public UnitOfWork(SifreKasasiAppContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
