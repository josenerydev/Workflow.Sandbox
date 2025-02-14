using Microsoft.Extensions.DependencyInjection;

using WorkflowCore.Interface;
using WorkflowCore.Sample01;
using WorkflowCore.Sample01.Steps;


var serviceProvider = ConfigureServices();
var host = serviceProvider.GetService<IWorkflowHost>();
host.RegisterWorkflow<HelloWorldWorkflow>();
host.Start();
await host.StartWorkflow("HelloWorld");

Console.ReadLine();
host.Stop();
return;

static IServiceProvider ConfigureServices()
{
    IServiceCollection services = new ServiceCollection();
    services.AddLogging();
    services.AddWorkflow();

    services.AddTransient<GoodbyeWorld>();

    var serviceProvider = services.BuildServiceProvider();

    return serviceProvider;
}