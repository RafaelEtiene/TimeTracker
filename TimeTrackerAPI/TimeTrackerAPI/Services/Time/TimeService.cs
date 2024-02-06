using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Services.Time
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;

        public TimeService(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public IEnumerable<Domain.Entities.Time> GetTimesByTask(int idTask)
        {
            try
            {
                return _timeRepository.GetTimesByTask(idTask);
            }
            catch(Exception e)
            {
                throw new Exception("An error has ocurred during request", e);
            }
        }

        public IEnumerable<Domain.Entities.Time> GetWorkedTimeOfDay()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Time> GetWorkedTimeOfMonth()
        {
            throw new NotImplementedException();
        }

        public bool InsertTime(Domain.Entities.Time time)
        {
            throw new NotImplementedException();
        }
    }
}
