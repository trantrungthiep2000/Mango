using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Mango.MessageBus
{
    /// <summary>
    /// Information of message bus
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class MessageBus : IMessageBus
    {
        private string connectionString = "Endpoint=sb://mangoweb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HjoslS58pPHtAULb0tay/jx4Ys0+MO5/R+ASbCcFTG0=";

        /// <summary>
        /// Publish message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="topicQueueName">Topic queue name</param>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public async Task PublishMessage(object message, string topicQueueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicQueueName);
            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);
            await sender.DisposeAsync();
        }
    }
}