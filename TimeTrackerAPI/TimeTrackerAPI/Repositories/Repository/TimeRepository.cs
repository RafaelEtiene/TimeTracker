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

        public IEnumerable<Time> GetTimesByTask(int idTask)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdTask", idTask);

                    var query = $"SELECT idTime,idTask,totalTime,date FROM time WHERE idTask = @IdTask";

                    return connection.Query<Time>(query, param);
                }
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Time> GetWorkedTimeOfDay()
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@Day", DateTime.Now.Day);

                    var query = $"SELECT idTime,idTask,totalTime,date FROM time WHERE DAY(date) = @Day";

                    return connection.Query<Time>(query, param);
                }
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Time> GetWorkedTimeOfMonth()
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@CurrentMonth", DateTime.Now.Month);

                    var query = $"SELECT idTime,idTask,totalTime,date FROM time WHERE MONTH(date) = @CurrentMonth";

                    return connection.Query<Time>(query, param);
                }
            }
            catch
            {
                throw;
            }
        }

        public bool InsertTime(Time time)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdTime", null);
                    param.Add("@IdTask", time.IdTask);
                    param.Add("@TotalTime", time.TotalTime);
                    param.Add("@Date", time.Date);

                    connection.Execute("INSERT INTO time (idTime,idTask,totalTime,date) VALUES (@IdTime,@IdTask,@TotalTime,@Date)", param);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
