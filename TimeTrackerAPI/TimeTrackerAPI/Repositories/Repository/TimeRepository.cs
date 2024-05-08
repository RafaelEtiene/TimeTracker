using Dapper;
using MySql.Data.MySqlClient;
using TimeTrackerAPI.Domain.Entities;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Repositories.Repository
{
    public class TimeRepository : ITimeRepository
    {
        private IConfiguration _configuration;

        public TimeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TimeSpan> GetTotalTimeTask(int idTask)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdTask", idTask);

                    var query = @"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(totalTime)))
                                FROM time
                                WHERE idTask = @IdTask";

                    return await connection.QuerySingleAsync<TimeSpan>(query, param);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<TimeSpan> GetWorkedTimeOfDay()
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@Day", DateTime.Now.Day);

                var query = @"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(totalTime)))
                            FROM time
                            WHERE DAY(date) = @Day";

                return await connection.QuerySingleAsync<TimeSpan>(query, param);
            }
        }

        public async Task<TimeSpan> GetWorkedTimeOfMonth()
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@CurrentMonth", DateTime.Now.Month);

                var query = @"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(totalTime)))
                            FROM time
                            WHERE MONTH(date) = @CurrentMonth";

                return await connection.QuerySingleAsync<TimeSpan>(query, param);
            }
        }

        public async Task<bool> InsertTime(Time time)
        {
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@IdTask", time.IdTask);
                param.Add("@TotalTime", time.TotalTime);

                var query = @"INSERT INTO time
                                (idTime,idTask,totalTime,date)
                                VALUES ((NULL,@IdTask,@TotalTime,NOW())";

                await connection.ExecuteAsync(query, param);
            }

            return true;
        }

        public async Task<IEnumerable<TimeByTask>> GetCurrentTimeByTasks()
        {
            using(var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = @"SELECT tk.idTask AS IdTask, tk.name AS NameTask, SUM(TIME_TO_SEC(tm.totalTime)) AS TotalTime
                              FROM `task` tk
                              JOIN `time` tm ON tk.idTask = tm.idTask
                              JOIN `typetask` tt ON tk.type = tt.idType
                              WHERE DATE(`date`) = CURRENT_DATE
                              GROUP BY tk.idTask
                              ORDER BY tt.idType;";

                connection.Open();

                return await connection.QueryAsync<TimeByTask>(query);
            }
        }
    }
}
