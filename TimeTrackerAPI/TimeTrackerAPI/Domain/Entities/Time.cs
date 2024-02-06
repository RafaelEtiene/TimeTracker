namespace TimeTrackerAPI.Domain.Entities
{
    public class Time
    {
        public int IdTime { get; set; }
        public int IdTask { get; set; }
        public TimeSpan TotalTime { get; set; }
        public DateTime Date { get; set; }
    }
}
