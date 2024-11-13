using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepository<Address> _addressRepository;

        [HttpPost]
        public ActionResult PostUser([FromBody] Address address)
        {
            _addressRepository.Add(address);
            return CreatedAtAction(nameof(GetAllAddress), new { id = address.IdEnde }, address);
        }

        [HttpGet]
        public ActionResult<Address> GetAllAddress()
        {
            var address = _addressRepository.GetAll();
            return Ok(address);
        }

        [HttpPut]
        public ActionResult PutAddress([FromBody] Address address)
        {
            if (address?.IdEnde == null)
            {
                return BadRequest("Id não existe");
            }

            _addressRepository.Update(address);
            return Ok(address);
        }

        [HttpDelete]
        public ActionResult DeleteAddress([FromBody] Address address)
        {
            _addressRepository.Delete(address);
            return Ok();
        }
    }
}
