using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext appDbContext;
        public QuestionService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<string> AddQues(QuestionDTO q)
        {
            var d = new Question()
            {
                Title = q.Title,
                Option1 = q.Option1,
                Option2 = q.Option2,
                Option3 = q.Option3,
                Option4 = q.Option4,
                CorrectId = q.CorrectId,
                CorrectMark = q.CorrectMark,
                WrongMark = q.WrongMark,
                SubId = q.SubId
            };
            await appDbContext.AddAsync(d);
            await appDbContext.SaveChangesAsync();
            return("Added Successfully");
        }

        public async Task<string> DeleteQues(int id)
        {
            var d = await appDbContext.Questions.FirstOrDefaultAsync(n => n.Id == id);
            if(d!=null)
            {
                appDbContext.Remove(d);
                return ("Deleted Successfully");
            }
            return ("No such Question Exists");
        }

        public async Task<Question> GetQuestionbyId(int id)
        {
            var d = await appDbContext.Questions.FirstOrDefaultAsync(n => n.Id == id);
                return d;
            
        }

        public async Task<List<Question>> GetQuestionBysubId(int id)
        {
            var d = await appDbContext.Questions.Where(n => n.SubId == id).ToListAsync();
            return (d);
        }

        public async Task<string> Modify(int id, QuestionDTO q)
        {
            var d = await appDbContext.Questions.FirstOrDefaultAsync(n => n.Id == id);
            if (d != null)
            {
                d.Title = q.Title;
                d.Option1 = q.Option1;
                d.Option2 = q.Option2;
                d.Option3 = q.Option3;
                d.Option4 = q.Option4;
                d.CorrectId = q.CorrectId;
                d.CorrectMark = q.CorrectMark;
                d.WrongMark = q.WrongMark;
                d.SubId = q.SubId;
                await appDbContext.SaveChangesAsync();
                return ("Updated successfully");
            }
            else
                return ("NotFOund");
        }
    }
}
