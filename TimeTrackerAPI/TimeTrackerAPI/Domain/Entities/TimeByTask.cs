namespace TimeTrackerAPI.Domain.Entities
{
    public class TimeByTask
    {
        public int IdTask { get; set; }

        public string NameTask { get; set; }

        public string Type { get; set; }

        public TimeSpan TotalTime { get; set; }

    }
}
