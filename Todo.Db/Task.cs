using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Db
{
    public class Task
    {
        public ObjectId Id { get; set; }
        public DateTime DueTime { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
