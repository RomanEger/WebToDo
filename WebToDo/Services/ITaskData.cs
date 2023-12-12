using WebToDo.Models;

namespace WebToDo.Services
{
    public interface ITaskData
    {
        Task<IEnumerable<Tasks>> GetAll(int idUser);
        public Task<Tasks> Get(int id);
        Task<int> Add(Tasks newtask);
        Task<int> Update(Tasks task);
        Task<int> Delete(Tasks task);
        Task<int> GetUserId(string email, string password);
    }
}
