namespace Mango.MessageBus
{
    /// <summary>
    /// Information of interface message bus
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Publish message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="topicQueueName">Topic queue name</param>
        /// <returns></returns>
        /// ThiepTT(13/09/2023)
        public Task PublishMessage(object message, string topicQueueName);
    }
}