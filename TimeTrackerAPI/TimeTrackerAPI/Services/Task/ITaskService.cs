namespace TimeTrackerAPI.Services.Task
{
    public interface ITaskService
    {
        public Task<IEnumerable<Domain.Entities.Task>> GetAllTasks();

        public Task<bool> InsertTask(Domain.Entities.Task task);

        public Task<bool> UpdateTask(Domain.Entities.Task task);

        public Task<bool> DeleteTask(int idTask);
    }
}
