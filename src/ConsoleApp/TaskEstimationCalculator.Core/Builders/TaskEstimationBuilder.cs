using TaskEstimationCalculator.Core.DomainObjects;
using TaskEstimationCalculator.Core.ValueObjects;

namespace TaskEstimationCalculator.Core.Builders
{
    public class TaskEstimationBuilder : IBuilder<TaskEstimation>
    {
        private readonly TaskEstimation _taskEstimation;

        public TaskEstimationBuilder() => _taskEstimation = new TaskEstimation();

        public TaskEstimationBuilder WithName(string name)
        {
            _taskEstimation.SetName(name);

            return this;
        }

        public TaskEstimationBuilder WithOptimisticEstimate(int estimate)
        {
            _taskEstimation.SetOptimisticEstimate(estimate);

            return this;
        }

        public TaskEstimationBuilder WithPessimisticEstimate(int estimate)
        {
            _taskEstimation.SetPessimisticEstimate(estimate);

            return this;
        }

        public TaskEstimationBuilder WithMostLikelyEstimate(int estimate)
        {
            _taskEstimation.SetMostLikelyEstimate(estimate);

            return this;
        }

        public TaskEstimation Build()
            => _taskEstimation;
    }
}
