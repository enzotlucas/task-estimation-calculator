using TaskEstimationCalculator.Core.Builders;
using TaskEstimationCalculator.Core.DomainObjects;
using TaskEstimationCalculator.Core.Exceptions;
using TaskEstimationCalculator.Core.Repositories;

namespace TaskEstimationCalculator.Core.Commands
{
    public class EstimateTaskCommand : ICommand
    {
        private readonly ITaskEstimationRepository _repository;

        private string _taskName;
        private int _optimisticEstimate;
        private int _mostLikelyEstimate;
        private int _pessimisticEstimate;

        public EstimateTaskCommand(ITaskEstimationRepository repository)
        {
            _repository = repository;
        }

        public Task Execute()
        {
            try
            {
                return TryExecute();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);

                return Execute();
            }
        }

        public Task TryExecute()
        {
            RequestTaskFields();

            var task = new TaskEstimationBuilder()
                            .WithName(_taskName)
                            .WithPessimisticEstimate(_pessimisticEstimate)
                            .WithMostLikelyEstimate(_mostLikelyEstimate)
                            .WithOptimisticEstimate(_optimisticEstimate)
                            .Build();

            _repository.Add(task);

            Console.WriteLine(task);

            return Task.CompletedTask;
        }

        private void RequestTaskFields()
        {
            RequestTaskName();

            RequestOptimisticEstimate();

            RequestMostLikelyEstimate();

            RequestPessimisticEstimate();
        }

        private void RequestTaskName()
        {
            Console.WriteLine("What's the task name?");

            _taskName = Console.ReadLine();
        }

        private void RequestOptimisticEstimate()
        {
            Console.WriteLine("What's the task optimistic estimate? (Max 5 chars)");

            var inputValue = Console.ReadLine();

            if (!int.TryParse(inputValue.Length > 5 ? inputValue[..5] : inputValue[..], out _optimisticEstimate))
                throw new BusinessException("Invalid field - Optimistic estimate");
        }

        private void RequestMostLikelyEstimate()
        {
            Console.WriteLine("What's the task most likely estimate? (Max 5 chars)");

            var inputValue = Console.ReadLine();

            if (!int.TryParse(inputValue.Length > 5 ? inputValue[..5] : inputValue[..], out _mostLikelyEstimate))
                throw new BusinessException("Invalid field - Most likely estimate");
        }

        private void RequestPessimisticEstimate()
        {
            Console.WriteLine("What's the task pessimistic estimate? (Max 5 chars)");

            var inputValue = Console.ReadLine();

            if (!int.TryParse(inputValue.Length > 5 ? inputValue[..5] : inputValue[..], out _pessimisticEstimate))
                throw new BusinessException("Invalid field - Pessimistic estimate");
        }
    }
}
