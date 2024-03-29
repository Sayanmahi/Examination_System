﻿using Examination_System.Data.DTO;
using Examination_System.Data.Services;
using Examination_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examination_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService db;
        public ExamController(IExamService db)
        {
            this.db = db;
        }
        // GET: api/<MarkController>
        [HttpGet("[action]/{subid}")]
        [Authorize(Roles ="Student")]
        public async Task<List<Question>> GetQuestionswrtsub(int subid)
        {
            var d= await db.GetQuestions(subid);
            return (d);
        }

        // POST api/<MarkController>
        [HttpPost("[action]")]
        [Authorize(Roles ="Student")]
        public async Task<IActionResult> Storeans([FromBody] TempMarksDTO value)
        {
             await db.StoreAns(value);
            return Ok();

        }
        [HttpPost("[action]/{uid}/{subid}")]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> Submit(int uid,int subid)
        {
            var  d=await db.Submit(uid,subid);
            return Ok(d);

        }
        [HttpGet("[action]")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetResult(int uid)
        {
            var d= await db.GetResults(uid);
            return Ok(d);
        }

        // PUT api/<MarkController>/5
        [HttpPut("[action]")]
        [Authorize(Roles ="Student")]
        public async Task<IActionResult> Put([FromBody] TempMarksDTO value)
        {
            await db.UpdateAns(value);
            return Ok();
        }
        [HttpGet("[action]")]
        [Authorize(Roles ="Student")]
        public async Task<IActionResult> GetSubsbybid(int bid)
        {
            var d=await db.GetSubbyBid(bid);
            return Ok(d);
        }
    }
}
