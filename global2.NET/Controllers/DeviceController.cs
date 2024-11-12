using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IRepository<Device> _deviceRepository;

        [HttpPost]
        public ActionResult PostDevice([FromBody] Device device)
        {
            _deviceRepository.Add(device);
            return CreatedAtAction(nameof(GetAllDevices), new { id = device.Id }, device);
        }

        [HttpGet]
        public ActionResult<Device> GetAllDevices()
        {
            var device = _deviceRepository.GetAll();
            return Ok(device);
        }

        [HttpPut]
        public ActionResult PutDevice([FromBody] Device device)
        {
            if (device?.Id == null)
            {
                return BadRequest("Id não existe");
            }

            _deviceRepository.Update(device);
            return Ok(device);
        }

        [HttpDelete]
        public ActionResult DeleteDevice([FromBody] Device device)
        {
            _deviceRepository.Delete(device);
            return Ok();
        }
    }
}
