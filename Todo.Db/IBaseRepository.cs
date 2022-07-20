//IBaseRepository.cs

using LiteDB;
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
        List<T> All();
        T FindById(ObjectId id);
        void Update(T entity);
        bool Delete(ObjectId id);
    }
}
