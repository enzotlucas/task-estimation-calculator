using TaskEstimationCalculator.Core.Exceptions;

namespace TaskEstimationCalculator.Core.ValueObjects
{
    public class TaskEstimation
    {
        public long Id { get; set; }
        public string Name { get; private set; }
        public decimal OptimisticEstimate { get; private set; }
        public decimal MostLikelyEstimate { get; private set; }
        public decimal PessimisticEstimate { get; private set; }

        public override string ToString()
        {
            return $"Id = {Id} \nName = {Name} " +
                $"\nOptimistic Estimate = {OptimisticEstimate}" +
                $"\nMostLikely Estimate = {MostLikelyEstimate}" +
                $"\nPessimistic Estimate = {PessimisticEstimate}" +
                $"\nProbability Distribuition:{ProbabilityDistribuition():0.##}" +
                $"\nDivergence:{Divergence():0.##}";
        }

        public void SetName(string name)
        {
            Name = name;

            if (Name is null)
                throw new BusinessException("Invalid task name: the name can't be null.");

            if (Name.Length > 100)
                throw new BusinessException("Invalid task name: the char length can't be higher than 100.");
        }

        public void SetPessimisticEstimate(int estimate)
        {
            PessimisticEstimate = estimate;

            if (estimate < MostLikelyEstimate || estimate < OptimisticEstimate)
                throw new BusinessException("Invalid pessimistic estimate: the estimate can't be lower than the most likely or the optimistic.");

            if (estimate < 0)
                throw new BusinessException("Invalid pessimistic estimate: the estimate can't be lower than 0.");
        }

        public void SetMostLikelyEstimate(int estimate)
        {
            MostLikelyEstimate = estimate;

            if (estimate > PessimisticEstimate || estimate < OptimisticEstimate)
                throw new BusinessException("Invalid most likey estimate: the estimate can't be lower than the the optimistic or higher than the pessimistic.");

            if (estimate < 0)
                throw new BusinessException("Invalid most likey estimate: the estimate can't be lower than 0.");
        }

        public void SetOptimisticEstimate(int estimate)
        {
            OptimisticEstimate = estimate;

            if (estimate > MostLikelyEstimate || estimate > PessimisticEstimate)
                throw new BusinessException("Invalid optimistic estimate: the estimate can't be higher than the most likely or the pessimistic.");

            if (estimate < 0)
                throw new BusinessException("Invalid optimistic estimate: the estimate can't be lower than 0.");
        }

        public decimal ProbabilityDistribuition() => (OptimisticEstimate + (4 * MostLikelyEstimate) + PessimisticEstimate) / 4;

        public decimal Divergence() => (PessimisticEstimate - OptimisticEstimate) / 6;
    }
}
