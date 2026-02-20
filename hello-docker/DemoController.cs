
using hello_docker.Model.Request;
using hello_docker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace hello_docker
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        private readonly UserRepository _user;
        
        public DemoController(UserRepository user)
        {
            _user = user;
        }

        // GET: DemoController
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _user.GetAllUserDetailsAsync();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody]CreateUser request)
        {
            await _user.AddUser(request);
            return Ok("User added");
        }
    }
}
