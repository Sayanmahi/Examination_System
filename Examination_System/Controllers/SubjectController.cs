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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        // GET: api/<SubjectController>
        [HttpGet("[action]")]
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var f = await subjectService.Getsub();
            return (f);
        }

        // POST api/<SubjectController>
        [HttpPost("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectDTO value)
        {
            var f=await subjectService.Add(value);
            if(f== "Subject already exists")
                return NotFound(f);
            return Ok(f);
        }

        // PUT api/<SubjectController>/5
        [HttpPost("[action]")]
        public async Task<string> Addbranchconnection(int sid,int bid)
        {
            var r=await subjectService.AddBranchConnection(sid, bid);
            return(r);
        }
        [HttpDelete("[action]")]
        public async Task<string> Deletebranchconnection(int sid, int bid)
        {
            var r = await subjectService.DeleteBranchConnection(sid, bid);
            return (r);
        }
        [HttpGet("[action]")]
        public async Task<List<BranchDTO>> Getbranchbysub(int id)
        {
            var d=await subjectService.GetBranches(id);
            return d;
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<string> DeleteSubject(int id)
        {
            var a=await subjectService.Delete(id);
            return a;
        }
    }
}
