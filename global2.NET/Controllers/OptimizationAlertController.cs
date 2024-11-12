using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimizationAlertController : ControllerBase
    {
        private readonly IRepository<OptimizationAlert> _OAlertRepository;

        [HttpPost]
        public ActionResult Post([FromBody] OptimizationAlert alert)
        {
            _OAlertRepository.Add(alert);

            return CreatedAtAction(nameof(GetAllAlerts), new { id = alert.Id }, alert);
        }

        [HttpGet]
        public ActionResult<OptimizationAlert> GetAllAlerts()
        {
            var alerts = _OAlertRepository.GetAll();
            return Ok(alerts);
        }
    }
}
