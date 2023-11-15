using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebToDo.ExceptionClasses;
using WebToDo.Models;

namespace WebToDo.Services
{
    public class SqlUsersData : IUserData
    {
        private string conStr;
        private IConfiguration configuration;
        public SqlUsersData(IConfiguration conf)
        {
            conStr = conf.GetConnectionString("DefaultConnection");
            configuration = conf;
        }

        public async Task<int> Add(Users newUser)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                if (db == null)
                    throw new ConnectionError();
                var sqlQuery = "INSERT INTO Users (Email, Password) VALUES(@Email, @Password)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = await db.QueryFirstOrDefaultAsync<int>(sqlQuery, newUser);
                newUser.Id = userId.Value;
            }
            return newUser.Id;
        }

        public async Task<int> Delete(Users user)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                return await db.ExecuteAsync(sqlQuery, new { user.Id });
            }

        }

        public async Task<Users> Get(int id)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                return await db.QueryFirstOrDefaultAsync<Users>("SELECT * FROM Users WHERE Id=@id", new { id }) ??
                    throw new Exception("Такого пользователя не существует");
            }
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var list = await db.QueryAsync<Users>("SELECT * FROM Users");
                return list.ToList();
            }
        }

        public async Task<int> Save(Users user)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var sqlQuery = "UPDATE Users SET Email=@Email, Password=@Password WHERE Id=@Id";
                return await db.ExecuteAsync(sqlQuery, user);
            }
        }

        public async Task<int> Select(string Email, string Password)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var sqlQuery = $"SELECT Id FROM Users WHERE Email='{Email}' AND Password='{Password}'";
                int id = await db.QueryFirstOrDefaultAsync<int>(sqlQuery);
                return id;
            }
        }

        public async Task<IEnumerable<Tasks>> SelectUserTasks(int id)
        {
            using(IDbConnection db = new SqlConnection(conStr))
            {
                SqlTasksData sqlTasksData = new SqlTasksData(configuration);
                var list = await sqlTasksData.GetAll(id);
                return list;
            }
        }
    }
}
