using Microsoft.Extensions.DependencyInjection;
using Plain.RabbitMQ;
using RabbitMQ.Client;

namespace RabbitMQReportService
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("ampq://guest@localhost:5672"));
            services.AddScoped<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
                "report_exchange",
                "report_queue",
                "report.*",
               ExchangeType.Topic));
        }
    }
}
