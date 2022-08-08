using TaskEstimationCalculator.Core.Repositories;
using TaskEstimationCalculator.Core.ValueObjects;

namespace TaskEstimationCalculator.Infrastructure.Repositories
{
    public class TaskEstimationRepository : ITaskEstimationRepository
    {
        List<TaskEstimation> TaskEstimations { get; }

        public TaskEstimationRepository() => TaskEstimations = new List<TaskEstimation>();

        public void Add(TaskEstimation task)
        {
            var lastTask = TaskEstimations.LastOrDefault();

            task.Id = lastTask is not null ? lastTask.Id + 1 : 1;

            TaskEstimations.Add(task);
        }

        public List<TaskEstimation> GetAll() => TaskEstimations;
    }
}
