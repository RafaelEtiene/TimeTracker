using Dapper;
using MySql.Data.MySqlClient;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Repositories.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var query = @"SELECT idTask AS IdTask,name AS Name,type AS Type, createDate as CreateDate
                            FROM task;";

                return await connection.QueryAsync<Domain.Entities.Task>(query);
            }
        }

        public async Task<bool> InsertTask(Domain.Entities.Task task)
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@Name", task.Name);
                param.Add("@Type", task.Type);

                var query = @"INSERT INTO task
                            (idTask,name,type,createDate)
                            VALUES
                            (NULL,@Name,@Type,NOW());";

                await connection.ExecuteAsync(query, param);

                return true;
            }
        }

        public async Task<bool> UpdateTask(Domain.Entities.Task task)
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@IdTask", task.IdTask);
                param.Add("@Name", task.Name);
                param.Add("@Type", task.Type);

                var query = @"UPDATE task
                            SET name = @Name, type = @Type
                            WHERE idTask = @IdTask;";

                await connection.ExecuteAsync(query, param);

                return true;
            }
        }

        public async Task<bool> DeleteTask(int idTask)
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@IdTask", idTask);

                var query = @"DELETE FROM task
                        WHERE idTask = @IdTask;";

                await connection.ExecuteAsync(query, param);

                return true;
            }
        }
    }
}
