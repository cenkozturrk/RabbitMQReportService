using Microsoft.Extensions.DependencyInjection;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQReportService.Service;

namespace RabbitMQReportService
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://guest:guest@localhost:5672"));
            services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
                "report_exchange",
                "report_queue",
                "report.*",
               ExchangeType.Topic));

            services.AddSingleton<IMemoryRepostStorage, MemoryRepostStorage>();
            services.AddHostedService<ReportDataCollector>();
        }
    }
}
