using Examination_System.Data.DTO;
using Examination_System.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examination_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost("[action]")]
        public async Task<IActionResult> TeacherLogin(LoginDTO l)
        {
            var g = await userService.Teacherlogin(l);
            if (g == "Not")
                return NotFound("You are not authorized to enter this page");
            else
                return Ok(g);
        }

        // GET api/<UserController>/5
        [HttpPost("[action]")]
        public async Task<string> Login(LoginDTO l)
        {
            var g=await userService.Login(l);
            if (g == "Not")
                return ("Please register");
            return (g);


        }
        [HttpPost("[action]")]
        public async Task<string> LoginAdmin(LoginDTO l)
        {
            var g = await userService.AdminLogin(l);
            if (g == "Not")
                return ("Please register");
            return (g);


        }

        // POST api/<UserController>
        [HttpPost("[action]")]
        public async Task<string> Register([FromBody] UserDTO u)
        {
            var o = await userService.Register(u);
            if (o == "Exists")
                return ("User Already exists");
            else if (o == "Done")
                return ("Registered");
            else
                return ("Not registered");
        }

        // PUT api/<UserController>/5
        [HttpPut("[action]")]
        public async Task<string> AdminApprove(int id)
        {
            var f=await userService.AdminAprroval(id);
            if (f == "Approved")
                return ("Approved");
            else
                return ("Not Found");
        }
        [HttpPut("[action]")]
        public async Task<string> AdminDeny([FromBody] int id)
        {
            var f = await userService.AdminDenial(id);
            if (f == "Denied")
                return ("Denied");
            else
                return ("Not Found");
        }
        [HttpPut("[action]")]
        public async Task<string> UserAgainRequest([FromBody] int id)
        {
            var f = await userService.UserRequestAgain(id);
            return (f);
        }

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        [HttpGet("[action]")]
        public async Task<List<UserdisplayapproveDTO>> UserAskingapproval()
        {
            var d = await userService.Useraskingapproval();
            return d;

        }
    }

}
