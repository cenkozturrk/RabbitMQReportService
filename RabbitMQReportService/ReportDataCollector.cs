using Newtonsoft.Json;
using Plain.RabbitMQ;
using RabbitMQReportService.Entitie;

namespace RabbitMQReportService
{
    public class ReportDataCollector : IHostedService
    {
        private const int DEFAULT_QUANTITY = 100; 
        private  ISubscriber subscriber { get; }
        private readonly IMemoryRepostStorage memoryRepostStorage;
        public ReportDataCollector(ISubscriber subscriber)
        {
            this.subscriber = subscriber;
        }       

        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        private bool ProcessMessage(string message, IDictionary<string,object> headers)
        {
            if (message.Contains("Product"))
            {

            }
            else
            {
                var order = JsonConvert.DeserializeObject<Order>(message);
                if (memoryRepostStorage.Get().Any(r => r.ProductName == order.Name))
                {
                    memoryRepostStorage.Get().First(r => r.ProductName == order.Name).Count -= order.Quantity;
                }
                else
                {
                    memoryRepostStorage.add(new Report
                    {
                        ProductName = order.Name,
                        Count = DEFAULT_QUANTITY - order.Quantity
                    });
                }
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
