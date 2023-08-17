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
            var g = await context.Questions.Where(n => n.Id == subid).SumAsync(m => m.CorrectMark);
            var f = 0;
            foreach (var r in d)
            {
                f = f + r.Marks;
            }

                var x = new MarksObt()
                {
                    UserId = uid,
                    SubjectId = subid,
                    TotalGot = f,
                    Total=g
                };
                context.MarksObts.Add(x);
                await context.SaveChangesAsync();
            
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
        public async Task<List<ResultDTO>> GetResults(int uid)
        {
            var d = await context.MarksObts.Where(n => n.UserId == uid).ToListAsync();
            List<ResultDTO> rr = new List<ResultDTO>();
            foreach(var f in d)
            {
                var s = await context.Subjects.FirstOrDefaultAsync(n => n.Id == f.SubjectId);
                decimal g = (((decimal)f.TotalGot /(decimal) f.Total) * 100);
                var pr = "";
                if(g>=70)
                {
                    pr = "Passed";
                }
                else
                {
                    pr = "Failed";
                }

                var c = new ResultDTO()
                {
                    SubjectName = s.Name,
                    MarksGot = f.TotalGot,
                    TotalMarks = f.Total,
                    Status = pr,
                    SubjectPercentage = (decimal)g
                };
                rr.Add(c);
            }
            return (rr);
        }
    }
}
