using TaskEstimationCalculator.Core.DomainObjects;

namespace TaskEstimationCalculator.Core.Commands
{
    public class RequestActionCommand : ICommand
    {
        private readonly ICommandFactory _factory;
        private readonly List<CommandEnum> _actions;

        private int _selectedActionNumber;

        public RequestActionCommand(ICommandFactory factory)
        {
            _factory = factory;
            _actions = Enum.GetValues(typeof(CommandEnum)).Cast<CommandEnum>().ToList();
        }

        public async Task Run()
        {
            var selectedAction = RequestAction();

            var command = _factory.GetCommand(selectedAction);

            await command.Run();
        }

        private CommandEnum RequestAction()
        {
            Console.WriteLine("First, what action you want to execute? (only numbers)");

            foreach (var action in _actions.ToList())
                Console.WriteLine($"{(int)action} - {Enum.GetName(typeof(CommandEnum), action)}");

            WaitActionToBeSelected();

            return (CommandEnum)_selectedActionNumber;
        }

        private void WaitActionToBeSelected()
        {
            var validCommand = false;

            while (!validCommand)
            {
                var validCommandNumber = int.TryParse(Console.ReadLine(), out _selectedActionNumber);

                if (validCommandNumber && Enum.IsDefined(typeof(CommandEnum), _selectedActionNumber))
                    return;

                Console.WriteLine("Invalid action, try again.");

                continue;
            }
        }
    }
}
