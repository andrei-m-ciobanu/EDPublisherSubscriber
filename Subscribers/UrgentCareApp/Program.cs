using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using UrgentCareApp;

Console.WriteLine("UrgentCareApp");

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
                queueName: "VeryUrgent")))
    .Build();

await host.RunAsync();
