using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Db
{
    public class TaskRepository : BaseRepository<Task>
    {
        public override Task Create(Task entity)
        {
            Collection.EnsureIndex(x => x.Id);
            return Collection.Find(o => o.Id == entity.Id)?.FirstOrDefault();
        }
    }
}
