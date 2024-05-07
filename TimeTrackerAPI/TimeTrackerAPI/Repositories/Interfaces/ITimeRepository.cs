using TimeTrackerAPI.Domain.Entities;

namespace TimeTrackerAPI.Repositories.Interfaces
{
    public interface ITimeRepository
    {
        public Task<bool> InsertTime(Time time);

        public Task<TimeSpan> GetTotalTimeTask(int idTask);

        public Task<TimeSpan> GetWorkedTimeOfDay();

        public Task<TimeSpan> GetWorkedTimeOfMonth();

        public Task<IEnumerable<TimeByTask>> GetCurrentTimeByTasks();
    }
}
