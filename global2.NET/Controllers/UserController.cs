using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<PrincipalUser> _userRepository;

        public UserController(IRepository<PrincipalUser> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] PrincipalUser user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.IdUsua }, user);
        }

        [HttpGet]
        public ActionResult<PrincipalUser> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpPut]
        public ActionResult PutUser([FromBody] PrincipalUser user)
        {
            if (user?.IdUsua == null)
            {
                return BadRequest("Id não existe");
            }

            _userRepository.Update(user);
            return Ok(user);
        }

        [HttpDelete]
        public ActionResult DeleteUser([FromBody] PrincipalUser user)
        {
            _userRepository.Delete(user);
            return Ok();
        }
    }
}
