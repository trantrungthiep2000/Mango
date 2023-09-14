namespace Mango.Services.EmailAPI.Messagings
{
    /// <summary>
    /// Information of interface azure service bus consumer
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public interface IAzureServiceBusConsumer
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public Task Start();

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public Task Stop();
    }
}
