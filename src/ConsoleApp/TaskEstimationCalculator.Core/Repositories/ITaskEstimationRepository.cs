using TaskEstimationCalculator.Core.ValueObjects;

namespace TaskEstimationCalculator.Core.Repositories
{
    public interface ITaskEstimationRepository
    {
        void Add(TaskEstimation task);
        List<TaskEstimation> GetAll();
    }
}
