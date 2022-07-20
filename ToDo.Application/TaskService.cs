using System.Threading.Tasks;
using Todo.Db;

namespace ToDo.Services
{
    public class TaskService
    {
        private readonly TaskRepository taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Create(TaskDto task)
        {
            if (task.DueTime==null) throw new ArgumentNullException();
            taskRepository.Create(new Todo.Db.Task()
            {
                Description = task.Description,
                Done = task.Done,
                DueTime = (DateTime)task.DueTime
            });
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return taskRepository.All().Select(x => new TaskDto()
            {
                Description = x.Description,
                Done = x.Done,
                DueTime = x.DueTime,
                Id = x.Id.ToString(),
            });
        }


        public void SetDone(string id, bool value)
        {
            var toUpdate = taskRepository.FindById(new LiteDB.ObjectId(id));
            toUpdate.Done = value;
            taskRepository.Update(toUpdate);
        }

        public void Delete(string id)
        {
            taskRepository.Delete(new LiteDB.ObjectId(id));
        }
    }
}