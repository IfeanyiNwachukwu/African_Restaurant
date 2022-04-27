using Integration.MessageBus.Contracts;
using Integration.MessageBus.Utility;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System.Text;

namespace Integration.MessageBus.Fulfilment
{
    internal class AzureServiceBusMessageBus : IMessageBus
    {
        private string connectionString = "Endpoint=sb://africankitchen.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=M+Xl+8z6IIVG2uH3xkaSeckKxbodtYStIpSmxwFg9lw=";
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            ISenderClient senderClient = new TopicClient(connectionString,topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await senderClient.SendAsync(finalMessage);

            await senderClient.CloseAsync();
        }
    }
}