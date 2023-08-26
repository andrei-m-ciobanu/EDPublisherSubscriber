using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace UrgentCareApp
{
    internal class SubscriberBackgroundService : IHostedService, IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private AsyncEventingBasicConsumer consumer;

        internal SubscriberBackgroundService(IConnectionFactory connectionFactory, string queueName)
        {
            connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();

            var response = channel.QueueDeclarePassive(queueName);

            consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += ReceiveMessage;

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        private async Task ReceiveMessage(object? sender, BasicDeliverEventArgs eventArgs)
        {
            var body = eventArgs.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"{DateTime.Now} \n{message}");

            await Task.Yield();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            consumer.Received -= ReceiveMessage;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            channel.Close();
            channel.Dispose();

            connection.Close();
            connection.Dispose();
        }
    }
}
