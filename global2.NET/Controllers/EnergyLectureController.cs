using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyLectureController : ControllerBase
    {
        private readonly IRepository<EnergyLecture> _energyLRepository;

        public EnergyLectureController(IRepository<EnergyLecture> energyLRepository)
        {
            _energyLRepository = energyLRepository;
        }

        [HttpPost]
        public ActionResult PostLecture([FromBody] EnergyLecture lecture)
        {
            _energyLRepository.Add(lecture);
            return CreatedAtAction(nameof(GetAllLecture), new { id = lecture.Id }, lecture);
        }

        [HttpGet]
        public ActionResult<EnergyLecture> GetAllLecture()
        {
            var lecture = _energyLRepository.GetAll();
            return Ok(lecture);
        }

        [HttpPut]
        public ActionResult PutLecture([FromBody] EnergyLecture lecture)
        {
            if (lecture?.Id == null)
            {
                return BadRequest("Id não existe");
            }

            _energyLRepository.Update(lecture);
            return Ok(lecture);
        }

        [HttpDelete]
        public ActionResult DeleteLecture([FromBody] EnergyLecture lecture)
        {
            _energyLRepository.Delete(lecture);
            return Ok();
        }
    }
}
