using RabbitMQReportService.Entitie;

namespace RabbitMQReportService.Service
{
    public interface IMemoryRepostStorage
    {
        void add(Report reports);
        IEnumerable<Report> Get();
    }
}