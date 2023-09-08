using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAllByUserId(int id);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
