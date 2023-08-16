using Examination_System.Data.DTO;
using Examination_System.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examination_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        // GET: api/<QuestionController>
        [HttpPost("[action]")]
        public async Task<IActionResult> GetQuestionsbySubId([FromBody]int id)
        {
            var d = await questionService.GetQuestionBysubId(id);
            return Ok(d);

        }

        //// GET api/<QuestionController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<QuestionController>
        [HttpPost("[action]")]
        public async Task<IActionResult> Addquestion([FromBody] QuestionDTO value)
        {
            var d= await questionService.AddQues(value);
            return Ok(d);
        }

        // PUT api/<QuestionController>/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestionDTO value)
        {
            var d= await questionService.Modify(id, value);
            return Ok(d);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var d= await questionService.DeleteQues(id);
            return Ok(d);
        }
    }
}
