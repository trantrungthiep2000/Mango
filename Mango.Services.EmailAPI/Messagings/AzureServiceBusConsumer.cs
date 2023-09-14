using Azure.Messaging.ServiceBus;
using Mango.Services.EmailAPI.Models.Dtos;
using Mango.Services.EmailAPI.Services;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Services.EmailAPI.Messagings
{
    /// <summary>
    /// Information of azure service bus consumer
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly string serviceBusConnectionString;
        private readonly string emailCartQueue;
        private readonly EmailService _emailService;
        private ServiceBusProcessor _emailCartProcessor;

        public AzureServiceBusConsumer(IConfiguration configuration, EmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;
            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString")!;
            emailCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue")!;

            var client = new ServiceBusClient(serviceBusConnectionString);
            _emailCartProcessor = client.CreateProcessor(emailCartQueue);
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public async Task Start()
        {
            _emailCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
            _emailCartProcessor.ProcessErrorAsync += ErrorHandler;

            await _emailCartProcessor.StartProcessingAsync();
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public async Task Stop()
        {
            await _emailCartProcessor.StopProcessingAsync();
            await _emailCartProcessor.DisposeAsync();
        }

        private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
        {
            // this is where you will receive message
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            var objectMessage = JsonConvert.DeserializeObject<CartDto>(body);

            try
            {
                //TODO - try to log email
                await _emailService.EmailCartAndLog(objectMessage!);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}