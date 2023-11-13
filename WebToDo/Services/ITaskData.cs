using WebToDo.Models;

namespace WebToDo.Services
{
    public interface ITaskData
    {
        IEnumerable<Tasks> GetAll();
        public Tasks Get(int id);
        int Add(Tasks newTask);
        void Save(Tasks tasks);
        void Delete(Tasks tasks);
    }
}
