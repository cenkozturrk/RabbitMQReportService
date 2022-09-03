using RabbitMQReportService.Entitie;

namespace RabbitMQReportService.Service
{
    public class MemoryRepostStorage : IMemoryRepostStorage
    {
        private readonly IList<Report> _reports = new List<Report>();
        private readonly IMemoryRepostStorage memoryRepostStorage;

        public MemoryRepostStorage(IList<Report> reports, IMemoryRepostStorage memoryRepostStorage)
        {
            _reports = reports;
            this.memoryRepostStorage = memoryRepostStorage;
        }

        public void add(Report reports)
        {
            _reports.Add(reports);
        }


        public IEnumerable<Report> Get()
        {
            return _reports;
        }
    }
}
