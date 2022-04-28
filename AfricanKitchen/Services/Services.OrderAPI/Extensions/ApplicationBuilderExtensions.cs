using Services.OrderAPI.Contracts.Messaging;

namespace Services.OrderAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IAzureServiceBusConsumer ServiceBusConsumer { get; set; }

        public static IApplicationBuilder UseServiceBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAzureServiceBusConsumer>();
            var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStarted.Register(OnStop);
            return app;
        }
        private static void OnStart() => ServiceBusConsumer.Start();
        private static void OnStop() => ServiceBusConsumer.Stop();
    }
}
