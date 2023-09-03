using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data.Services
{
    public class BranchService : IBranchService
    {
        private readonly AppDbContext context;
        public BranchService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Add(AddBranchDTO name)
        {
            var d= await context.Branches.FirstOrDefaultAsync(n=> n.Name.ToLower()==name.Name.ToLower());
            if(d!=null)
            {
                return ("Already Exists");
            }
            else
            {
                var s = new Branch()
                {
                    Name = name.Name
                };
                await context.Branches.AddAsync(s);
                await context.SaveChangesAsync();
                if (name.SubjectIds.Count()>0)
                {
                    foreach(var i in name.SubjectIds)
                    {
                        var g = new BranchSubject()
                        {
                            SubjectId = i,
                            BranchId = s.Id

                        };
                        await context.AddAsync(g);
                        await context.SaveChangesAsync();
                    }
                }
                return ("Added Successfully");
            }
        }

        public async Task<string> AddSubjectConnection(int sid, int bid)
        {
            var d= await context.BranchSubjects.FirstOrDefaultAsync(n=> n.BranchId==bid && n.SubjectId==sid);
            if(d!=null)
            {
                return ("Connection already exists");
            }
            else
            {
                var f = new BranchSubject()
                {
                    SubjectId = sid,
                    BranchId = bid
                };
                await context.BranchSubjects.AddAsync(f);
                await context.SaveChangesAsync();
                return ("Connection Established successfully");
            }
        }

        public async Task<string> Delete(int id)
        {
            var d= await context.Branches.FirstOrDefaultAsync(n=> n.Id==id);
            if(d==null)
            {
                return ("No Such Branch Found");
            }
            context.Remove(d);
            await context.SaveChangesAsync();
            return ("Branch Deleted Successfully");
        }

        public async Task<string> DeleteSubjectConnection(int sid, int bid)
        {
            var d = await context.BranchSubjects.FirstOrDefaultAsync(n => n.BranchId == bid && n.SubjectId == sid);
            if(d!=null) 
            { 
                context.Remove(d);
                await context.SaveChangesAsync();
                return ("Connection Deleted Successfully");
            }
            return ("No such Connection Found");
        }

        public async Task<IEnumerable<Branch>> Getbranch()
        {
            var d = await context.Branches.ToListAsync();
            return (d);
        }

        public async Task<List<BranchDTO>> GetSubbyBranch(int branid)
        {
            var d = await context.BranchSubjects.Where(n => n.BranchId == branid).ToListAsync();
            List<BranchDTO> dd = new List<BranchDTO>();
            foreach(var i in d)
            {
                var f = await context.Subjects.FirstOrDefaultAsync(n => n.Id == i.SubjectId);
                var x = new BranchDTO()
                {
                    Id = f.Id,
                    Name = f.Name
                };
                dd.Add(x);
            }
            return (dd);
        }

        public async Task<List<DisplaySubjectsDTO>> GetSubjects(int branid)
        {
            var d = await context.BranchSubjects.Where(n=> n.BranchId==branid).ToListAsync();
            List<DisplaySubjectsDTO> dd= new List<DisplaySubjectsDTO>();
            if(d.Count>0)
            {
                foreach(var i in  d)
                {
                    var g= await context.Subjects.FirstOrDefaultAsync(n=> n.Id==i.SubjectId);
                    var f = new DisplaySubjectsDTO()
                    {
                        id = g.Id,
                        Name = g.Name
                    };
                    dd.Add(f);
                }
            }
            return (dd);
        }
    }
}
