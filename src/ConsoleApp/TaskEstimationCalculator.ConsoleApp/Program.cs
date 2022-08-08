using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskEstimationCalculator.Core.Commands;
using TaskEstimationCalculator.Core.DomainObjects;
using TaskEstimationCalculator.Core.Repositories;
using TaskEstimationCalculator.Infrastructure.Repositories;

Console.Title = "Task Estimation Calculator";

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddScoped<ICommandFactory, CommandFactory>()
                .AddScoped<ITaskEstimationRepository, TaskEstimationRepository>()
                .AddScoped<EstimateTaskCommand>()
                .AddScoped<ListTaskEstimationsCommand>()
                .AddScoped<RequestActionCommand>())
    .Build();

var requestActionCommand = (RequestActionCommand)host.Services.GetRequiredService(typeof(RequestActionCommand));

await Run(requestActionCommand);

Console.WriteLine("\n\nPress any key to shut down...");

Console.ReadKey();

static async Task Run(RequestActionCommand requestActionCommand)
{
    var useSystemAgain = string.Empty;

    while (string.IsNullOrEmpty(useSystemAgain) || !useSystemAgain.Equals("N", StringComparison.OrdinalIgnoreCase))
    {
        Console.Clear();

        Console.WriteLine("Welcome to the Task Estimation Calculator!\nPlease input the requested informations.");

        await requestActionCommand.Run();

        Console.WriteLine("Use system again? (Y/N)");

        useSystemAgain = Console.ReadLine();
    }
}