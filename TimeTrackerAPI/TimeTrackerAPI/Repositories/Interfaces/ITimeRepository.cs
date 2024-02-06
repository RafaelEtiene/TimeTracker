using TimeTrackerAPI.Domain.Entities;

namespace TimeTrackerAPI.Repositories.Interfaces
{
    public interface ITimeRepository
    {
        public bool InsertTime(Time time);

        public IEnumerable<Time> GetTimesByTask(int idTask);

        public IEnumerable<Time> GetWorkedTimeOfDay();

        public IEnumerable<Time> GetWorkedTimeOfMonth();
    }
}
