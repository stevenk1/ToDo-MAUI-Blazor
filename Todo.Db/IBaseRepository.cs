//IBaseRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Db
{
    public interface IBaseRepository<T>
    {
        T Create(T data);
        IEnumerable<T> All();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);
    }
}
