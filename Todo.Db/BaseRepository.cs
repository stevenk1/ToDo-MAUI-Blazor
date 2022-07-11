using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Db
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private const string _databaseName = "todo.db";
        public ILiteCollection<T> Collection { get; }

        public BaseRepository()
        {
            var filePath = Path.Combine(
               FileSystem.Current.AppDataDirectory,
                _databaseName);

            using var db = new LiteDatabase(filePath);
            Collection = db.GetCollection<T>();
        }

        public virtual T Create(T entity)
        {
            var newId = Collection.Insert(entity);
            return Collection.FindById(newId.AsInt32);
        }

        public virtual IEnumerable<T> All()
        {
            return Collection.FindAll();
        }

        public virtual T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        public virtual bool Delete(int id)
        {
            return Collection.Delete(id);
        }
    }
}
