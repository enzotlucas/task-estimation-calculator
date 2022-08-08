using TaskEstimationCalculator.Core.DomainObjects;
using TaskEstimationCalculator.Core.Repositories;

namespace TaskEstimationCalculator.Core.Commands
{
    public class ListTaskEstimationsCommand : ICommand
    {
        private readonly ITaskEstimationRepository _repository;

        public ListTaskEstimationsCommand(ITaskEstimationRepository repository)
        {
            _repository = repository;
        }

        public Task Run()
        {
            var tasks = _repository.GetAll();

            foreach (var task in tasks)            
                Console.WriteLine($"\n{task}\n");

            return Task.CompletedTask;
        }
    }
}
