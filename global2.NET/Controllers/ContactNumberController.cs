using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactNumberController : ControllerBase
    {
        private readonly IRepository<ContactNumber> _telephoneRepository;

        public ContactNumberController(IRepository<ContactNumber> telephoneRepository)
        {
            _telephoneRepository = telephoneRepository;
        }

        [HttpPost]
        public ActionResult PostTelephone([FromBody] ContactNumber number)
        {
            _telephoneRepository.Add(number);
            return CreatedAtAction(nameof(GetAllTelephone), new { id = number.IdTelef }, number);
        }

        [HttpGet]
        public ActionResult<ContactNumber> GetAllTelephone()
        {
            var number = _telephoneRepository.GetAll();
            return Ok(number);
        }

        [HttpPut]
        public ActionResult PutTelephone([FromBody] ContactNumber number)
        {
            if (number?.IdTelef == null)
            {
                return BadRequest("Id não existe");
            }

            _telephoneRepository.Update(number);
            return Ok(number);
        }

        [HttpDelete]
        public ActionResult DeleteTelephone([FromBody] ContactNumber number)
        {
            _telephoneRepository.Delete(number);
            return Ok();
        }
    }
}
