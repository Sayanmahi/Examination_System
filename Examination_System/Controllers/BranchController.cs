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
    public class BranchController : ControllerBase
    {
        public readonly IBranchService db;
        public BranchController(IBranchService _db)
        {
            db = _db;
        }
        // GET: api/<BranchController>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSubjects(int id)
        {
            var d = await db.GetSubjects(id);
            return Ok(d);
        }

        //GET api/<BranchController>/5
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBranches()
        {
            var d = await db.Getbranch();
            return Ok(d);
        }

        // POST api/<BranchController>
        [HttpPost("[action]")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchDTO value)
        {
            var d = await db.Add(value);
            return Ok(d);
        }
       
        [HttpPost("[action]/{sid}/{bid}")]
        public async Task<IActionResult> AddSubjecttoBranch(int sid, int bid)
        {
            var d = await db.AddSubjectConnection(sid, bid);
            return Ok(d);
        }
        [HttpDelete("[action]/{sid}/{bid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int sid, int bid)
        {
            var d = await db.DeleteSubjectConnection(sid, bid);
            return Ok(d);
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var d = await db.Delete(id);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSubbyBranch(int id)
        {
            var d = await db.GetSubbyBranch(id);
            return Ok(d);
        }

    }
}
