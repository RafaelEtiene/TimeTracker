namespace TimeTrackerAPI.Services.Time
{
    public interface ITimeService
    {
        public bool InsertTime(TimeTrackerAPI.Domain.Entities.Time time);

        public IEnumerable<TimeTrackerAPI.Domain.Entities.Time> GetTimesByTask(int idTask);

        public IEnumerable<TimeTrackerAPI.Domain.Entities.Time> GetWorkedTimeOfDay();

        public IEnumerable<TimeTrackerAPI.Domain.Entities.Time> GetWorkedTimeOfMonth();
    }
}
