using EDViewApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

Console.WriteLine("EDViewApp");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddSingleton<IConnectionFactory>(serviceProvider => new ConnectionFactory
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            })
            .AddHostedService(seviceProvider => new SubscriberBackgroundService(
                connectionFactory: seviceProvider.GetService<IConnectionFactory>()!,
                queueName: "Patient")))
    .Build();

await host.RunAsync();
