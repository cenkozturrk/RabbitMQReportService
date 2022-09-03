using Plain.RabbitMQ;

namespace RabbitMQReportService
{
    public class ReportDataCollector : IHostedService
    {
        private  ISubscriber subscriber { get; }
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
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
