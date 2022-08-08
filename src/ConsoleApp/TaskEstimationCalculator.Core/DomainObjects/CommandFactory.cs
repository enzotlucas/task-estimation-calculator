using TaskEstimationCalculator.Core.Commands;
using TaskEstimationCalculator.Core.Exceptions;

namespace TaskEstimationCalculator.Core.DomainObjects
{
    public class CommandFactory : ICommandFactory
    {
        private readonly EstimateTaskCommand _estimateTaskCommand;
        private readonly ListTaskEstimationsCommand _listTaskEstimationsCommand;

        public CommandFactory(EstimateTaskCommand estimateTaskCommand, 
                              ListTaskEstimationsCommand listTaskEstimationsCommand)
        {
            _estimateTaskCommand = estimateTaskCommand;
            _listTaskEstimationsCommand = listTaskEstimationsCommand;
        }

        public ICommand GetCommand(CommandEnum command)
        {
            var commandExists = Commands.TryGetValue(command, out var builder);

            if (!commandExists)
                throw new BusinessException("Unexistent command.");

            return builder;
        }

        private IDictionary<CommandEnum, ICommand> Commands =>
            new Dictionary<CommandEnum, ICommand>
            {
                {CommandEnum.EstimateTask, _estimateTaskCommand },
                {CommandEnum.ListTaskEstimations, _listTaskEstimationsCommand }
            };
    }

    public interface ICommandFactory
    {
        ICommand GetCommand(CommandEnum command);
    }

    public enum CommandEnum
    {
        EstimateTask = 1,
        ListTaskEstimations = 2
    }
}
