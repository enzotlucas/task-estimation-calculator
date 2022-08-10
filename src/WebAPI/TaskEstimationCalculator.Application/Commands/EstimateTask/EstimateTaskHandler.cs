using MediatR;
using TaskEstimationCalculator.Application.ViewModels;

namespace TaskEstimationCalculator.Application.Commands.EstimateTask
{
    public class EstimateTaskHandler : IRequestHandler<EstimateTask, TaskEstimationViewModel>
    {
        public EstimateTaskHandler()
        {

        }

        public async Task<TaskEstimationViewModel> Handle(EstimateTask request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
