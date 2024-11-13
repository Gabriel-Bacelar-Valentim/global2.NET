using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IncentiveScoreController : ControllerBase
    {
        private readonly IRepository<IncentiveScore> _scoreRepository;

        [HttpPost]
        public ActionResult PostScore([FromBody] IncentiveScore score)
        {
            _scoreRepository.Add(score);
            return CreatedAtAction(nameof(GetAllScores), new { id = score.IdPont }, score);
        }

        [HttpGet]
        public ActionResult<IncentiveScore> GetAllScores()
        {
            var score = _scoreRepository.GetAll();
            return Ok(score);
        }

        [HttpPut]
        public ActionResult PutScore([FromBody] IncentiveScore score)
        {
            if (score?.IdPont == null)
            {
                return BadRequest("Id não existe");
            }

            _scoreRepository.Update(score);
            return Ok(score);
        }

        [HttpDelete]
        public ActionResult DeleteScore([FromBody] IncentiveScore score)
        {
            _scoreRepository.Delete(score);
            return Ok();
        }
    }
}
