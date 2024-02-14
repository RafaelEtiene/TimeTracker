using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();    
        }

        public async Task<bool> InsertTask(Domain.Entities.Task task)
        {
            return await _taskRepository.InsertTask(task);
        }

        public async Task<bool> UpdateTask(Domain.Entities.Task task)
        {
            return await _taskRepository.UpdateTask(task);
        }

        public async Task<bool> DeleteTask(int idTask)
        {
            return await _taskRepository.DeleteTask(idTask);
        }
    }
}
