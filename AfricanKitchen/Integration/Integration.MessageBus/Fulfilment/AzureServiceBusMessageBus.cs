using Azure.Messaging.ServiceBus;
using Integration.MessageBus.Contracts;
using Integration.MessageBus.Helpers;
using Integration.MessageBus.Utility;
using Newtonsoft.Json;
using System.Text;

namespace Integration.MessageBus.Fulfilment
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
       
       /// <summary>
       /// Posts a message inside the Azure topic
       /// </summary>
       /// <param name="message"></param>
       /// <param name="topicName"></param>
       /// <returns></returns>
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            await using var client = new ServiceBusClient(StaticDetails.AzureServiceBusConnectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();
        }
    }
}