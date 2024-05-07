using TimeTrackerAPI.Domain.Entities;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Services.Time
{
    public class TimeService : ITimeService
    {
        public ITimeRepository _repository { get; set; }
        public TimeService(ITimeRepository timeRepository)
        {
            _repository = timeRepository;
        }

        public async Task<TimeSpan> GetTotalTimeTask(int idTask)
        {
            try
            {
                return await _repository.GetTotalTimeTask(idTask);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TimeSpan> GetWorkedTimeOfDay()
        {
            try
            {
                return await _repository.GetWorkedTimeOfDay();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TimeSpan> GetWorkedTimeOfMonth()
        {
            try
            {
                return await _repository.GetWorkedTimeOfMonth();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertTime(Domain.Entities.Time time)
        {
            try
            {
                return await _repository.InsertTime(time);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TimeByTask>> GetCurrentTimeByTasks()
        {
            try
            {
                var lsTimeTask = await _repository.GetCurrentTimeByTasks();
                return await _repository.GetCurrentTimeByTasks();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
