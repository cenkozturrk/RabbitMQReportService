using RabbitMQReportService.Entitie;

namespace RabbitMQReportService
{
    public interface IMemoryRepostStorage
    {
        void add(Report reports);
        IEnumerable<Report> Get();
    }
}