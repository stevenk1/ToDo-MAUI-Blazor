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

        public ILiteDatabase GetDatabase()
        {
            var filePath = Path.Combine(
              FileSystem.Current.AppDataDirectory,
               _databaseName);
            return new LiteDatabase(filePath);

        }

        public virtual T Create(T entity)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<T>();
            var  id=collection.Insert(entity);
            return collection.FindById(id);
        }

        public virtual List<T> All()
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<T>();
            return collection.FindAll().ToList();
        }

        public virtual T FindById(ObjectId id)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<T>();
            return collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<T>();
            collection.Upsert(entity);
        }

        public virtual bool Delete(ObjectId id)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<T>();
            return collection.Delete(id);
        }

    }
}
