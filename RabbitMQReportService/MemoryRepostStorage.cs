namespace RabbitMQReportService
{
    public class MemoryRepostStorage
    {
        private IList<Report> _reports = new List<Report>();

        public MemoryRepostStorage(IList<Report> reports)
        {
            _reports = reports;
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
