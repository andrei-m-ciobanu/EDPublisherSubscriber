namespace EmergencyDepartment.SecondaryAdapter.Publisher
{
    public interface IMessageQueuePublisher : IDisposable
    {
        void SendMessage<T>(string topic, T payload) where T : class;
    }
}
