using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressController(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] Address address)
        {
            _addressRepository.Add(address);
            return CreatedAtAction(nameof(GetAllAddress), new { id = address.IdEnde }, address);
        }

        [HttpGet]
        public ActionResult GetAllAddress()
        {
            var addresses = _addressRepository.GetAll();
            return Ok(addresses);
        }

        [HttpPut]
        public ActionResult PutAddress([FromBody] Address address)
        {
            if (address?.IdEnde == null)
            {
                return BadRequest("Address ID cannot be null.");
            }

            _addressRepository.Update(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }

            _addressRepository.Delete(address);
            return NoContent();
        }
    }
}