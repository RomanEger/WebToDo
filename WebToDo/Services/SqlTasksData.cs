using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebToDo.ExceptionClasses;
using WebToDo.Models;

namespace WebToDo.Services
{
    public class SqlTasksData : ITaskData
    {
        private string conStr;

        public SqlTasksData(IConfiguration conf)
        {
            conStr = conf.GetConnectionString("DefaultConnection");
        }

        public async Task<int> Add(Tasks newUser)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                if (db == null)
                    throw new ConnectionError();
                var sqlQuery = "INSERT INTO Tasks (IdUser, Title, Content, IsCompleted) VALUES(@IdUser, @Title, @Content, @IsCompleted)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = await db.QueryFirstOrDefaultAsync<int>(sqlQuery, newUser);
                newUser.Id = userId.Value;
            }
            return newUser.Id;
        }

        public async Task<int> Delete(Tasks user)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var sqlQuery = "DELETE FROM Tasks WHERE Id = @id";
                return await db.ExecuteAsync(sqlQuery, new { user.Id });
            }

        }

        public async Task<Tasks> Get(int id)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                return await db.QueryFirstOrDefaultAsync<Tasks>($"SELECT * FROM Tasks WHERE Id={id}") ?? new Tasks();
            }
        }

        public async Task<IEnumerable<Tasks>> GetAll(int idUser)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                return await db.QueryAsync<Tasks>($"SELECT * FROM Tasks WHERE IdUser={idUser}");
            }
        }

        public async Task<int> Update(Tasks user)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                var sqlQuery = "UPDATE Tasks SET Title=@Title, Content=@Content, IsCompleted=@IsCompleted WHERE Id=@Id";
                return await db.ExecuteAsync(sqlQuery, user);
            }
        }
        
        public async Task<int> GetUserId(string email, string password)
        {
            using (IDbConnection db = new SqlConnection(conStr))
            {
                //SqlUsersData sqlUsersData = new SqlUsersData(conf);
                var sqlQuery = $"SELECT Id FROM Users WHERE Email='{email}' AND Password='{password}'";
                return await db.QueryFirstOrDefaultAsync<int>(sqlQuery);
            }
        }

    }
}
