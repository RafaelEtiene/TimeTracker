namespace TimeTrackerAPI.Domain.Entities
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
