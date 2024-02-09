using Examination_System.Data.DTO;
using Examination_System.Data.Services;
using Examination_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examination_System.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteService db;
        public InstituteController(IInstituteService db)
        {
            this.db = db;
        }
        // GET: api/<InstituteController>
        [HttpGet("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IEnumerable<Institute>> GetAll()
        {
            var d=await db.GetAll();
            return d;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Subject>> GetMySubjectsByTeacherId(int id)
        {
            var d = await db.ShowmysubjectsByTeacherId(id);
            return (d);
        }

        // GET api/<InstituteController>/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetInstById(int id)
        {
            var d = await db.GetInstByid(id);
            return Ok(d);
        }

        // POST api/<InstituteController>
        [HttpPost("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddInst([FromBody] InstDTO value)
        {
            var d= await db.AddInst(value);
            return Ok(d);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherDTO value)
        {
            var d = await db.AddTeacher(value);
            return Ok(d);
        }

        // PUT api/<InstituteController>/5
        [HttpPut("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] InstDTO value)
        {
            var d= await db.UpdateInst(id,value);
            return Ok(d);
        }

        // DELETE api/<InstituteController>/5
        [HttpDelete("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var d = await db.DeleteInstitute(id);
            return Ok(d);
        }
    }
}
