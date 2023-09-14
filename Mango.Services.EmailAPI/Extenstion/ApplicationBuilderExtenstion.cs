using Mango.Services.EmailAPI.Messagings;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Mango.Services.EmailAPI.Extenstion
{
    /// <summary>
    /// Information of application builder extenstion
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public static class ApplicationBuilderExtenstion
    {
        private static IAzureServiceBusConsumer ServiceBusConsumer { get; set; } = default!;

        /// <summary>
        /// Use azure service bus consumer
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <returns>IApplicationBuilder</returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public static IApplicationBuilder UseAzureServiceBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAzureServiceBusConsumer>()!;
            var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>()!;

            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStopping.Register(OnStop);

            return app;
        }

        private static void OnStop()
        {
            ServiceBusConsumer.Stop();
        }

        private static void OnStart()
        {
            ServiceBusConsumer.Start();
        }
    }
}
