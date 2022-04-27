using Integration.MessageBus.Utility;

namespace Integration.MessageBus.Contracts
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);

    }
}
