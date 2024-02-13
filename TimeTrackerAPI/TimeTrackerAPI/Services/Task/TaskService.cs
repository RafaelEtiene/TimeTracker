namespace TimeTrackerAPI.Services.Task
{
    public class TaskService : ITaskService
    {
        public async Task<bool> DeleteTask(int idTask)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertTask(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTask(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
