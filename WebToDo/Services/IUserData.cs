using WebToDo.Models;

namespace WebToDo.Services
{
    public interface IUserData
    {
        Task<IEnumerable<Users>> GetAll();
        public Task<Users> Get(int id);
        Task<int> Add(Users newUser);
        Task<int> Save(Users user);
        Task<int> Delete(Users user);
        Task<int> Select(string email, string password);
        Task<IEnumerable<Tasks>> SelectUserTasks(int id);
    }
}
