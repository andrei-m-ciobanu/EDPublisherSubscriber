using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EmergencyDepartment.SecondaryAdapter.Publisher
{
    public class MessageQueuePublisher : IMessageQueuePublisher
    {
        private IConnection connection;
        private IModel channel;
        private readonly string exchange;

        public MessageQueuePublisher(IConnectionFactory connectionFactory) 
        {
            connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            exchange = "ed";
        }

        public void SendMessage<T>(string topic, T payload) where T : class
        {
            channel.BasicPublish(exchange, 
                topic, 
                CreateBasicProperties(),
                GetJsonBytes(payload));
        }

        private static byte[] GetJsonBytes<T>(T payload) where T : class
        {
            var jsonPayload = JsonSerializer.Serialize(payload);
            return Encoding.UTF8.GetBytes(jsonPayload);
        }

        private IBasicProperties CreateBasicProperties()
        {
            var properties = channel.CreateBasicProperties();
            properties.ContentType = "application/json";
            properties.DeliveryMode = 2;
            return properties;
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
