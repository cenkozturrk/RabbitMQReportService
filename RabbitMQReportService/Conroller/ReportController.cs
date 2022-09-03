using Microsoft.AspNetCore.Mvc;
using RabbitMQReportService.Entitie;
using RabbitMQReportService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabbitMQReportService.Conroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMemoryRepostStorage _memoryRepostStorage;

        public ReportController(IMemoryRepostStorage memoryRepostStorage)
        {
            _memoryRepostStorage = memoryRepostStorage;
        }

        
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return _memoryRepostStorage.Get();
        }

       
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
       
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
