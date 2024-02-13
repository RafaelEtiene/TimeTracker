using TimeTrackerAPI.Domain.Entities;

namespace TimeTrackerAPI.Services.Time
{
    public interface ITimeService
    {
        public Task<bool> InsertTime(Domain.Entities.Time time);

        public Task<TimeSpan> GetTotalTimeTask(int idTask);

        public Task<TimeSpan> GetWorkedTimeOfDay();

        public Task<TimeSpan> GetWorkedTimeOfMonth();

        public Task<IEnumerable<TimeByTask>> GetTimeByTask();
    }
}
