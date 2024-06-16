using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T>
    {
        public T Add(T entity);
        public T Update(int id,T entity);
        public void Delete(int id);
        public T Get(int id);
        public List<T> GetAll();

    }
}
