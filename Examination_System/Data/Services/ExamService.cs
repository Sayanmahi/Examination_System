using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data.Services
{
    public class ExamService : IExamService
    {
        private readonly AppDbContext context;
        public ExamService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Question>> GetQuestions(int subid)
        {
            var d = await context.Questions.Where(n => n.SubId == subid).ToListAsync();
            return d;

        }

        public async Task StoreAns(TempMarksDTO mark)
        {
            var c = 0;
            var markss= await context.Questions.FirstOrDefaultAsync(n=> n.SubId==mark.SubId && n.Id==mark.QuesId);
            if (markss.CorrectId == mark.Option)
                c = markss.CorrectMark;
            else
                c = -markss.WrongMark;
            var d = new TempMark()
            {
                UserId = mark.UserId,
                SubId = mark.SubId,
                QuesId = mark.QuesId,
                Marks = c
            };
            await context.AddAsync(d);
            await context.SaveChangesAsync();
        }

        public async Task<string> Submit(int uid, int subid)
        {
            var d= await context.TempMarks.Where(n=> n.UserId==uid && n.SubId==subid).ToListAsync();
            foreach(var r in d)
            {
                var x = new MarksObt()
                {
                    UserId = r.UserId,
                    SubjectId = r.SubId,
                    QuesId = r.QuesId,
                    Total = r.Marks
                };
                context.MarksObts.Add(x);
                await context.SaveChangesAsync();
            }
             context.TempMarks.RemoveRange(d);
            await context.SaveChangesAsync();
            return ("Submitted Successfully");
        }

        public async Task UpdateAns(TempMarksDTO mark)
        {
            var c = 0;
            var m = await context.TempMarks.FirstOrDefaultAsync(n => n.UserId == mark.UserId && n.QuesId == mark.QuesId && n.SubId == mark.SubId);
            var right = await context.Questions.FirstOrDefaultAsync(n => n.Id == mark.QuesId);
            if(right.CorrectId== mark.Option)
            {
                m.Marks = right.CorrectMark;
            }
            else
            {
                m.Marks= -right.WrongMark;
            }
            await context.SaveChangesAsync();

        }
    }
}
