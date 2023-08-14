using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Examination_System.Data.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext context;
        public SubjectService(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<string> Add(SubjectDTO name)
        {
            var d=await context.Subjects.FirstOrDefaultAsync(x => x.Name.ToLower() == name.Name.ToLower());
            if (d != null)
            {
                return ("Subject already exists");
            }
            else
            {
                var c = new Subject()
                {
                    Name = name.Name
                };
                await context.AddAsync(c);
                await context.SaveChangesAsync();
                if (name.BranchIds.Count > 0)
                {
                    foreach (var k in name.BranchIds)
                    {
                        var p = new BranchSubject()
                        {
                            SubjectId = c.Id,
                            BranchId = k

                        };
                        await context.AddAsync(p);
                        await context.SaveChangesAsync();

                    }
                }
                return ("Subject Added Successfully");
            }
        }

        public async Task<string> AddBranchConnection(int sid, int bid)
        {
            var t = await context.BranchSubjects.FirstOrDefaultAsync(n => n.BranchId == bid && n.SubjectId == sid);
            if(t==null)
            {
                var b = new BranchSubject()
                {
                    SubjectId = sid,
                    BranchId = bid
                };
                await context.AddAsync(b);
                await context.SaveChangesAsync();
                return ("Added Successfully");
            }
            return ("Connection Already Exists");
        }

        public async Task<string> Delete(int id)
        {
            var p= await context.BranchSubjects.Where(n=>n.SubjectId==id).ToListAsync();
            context.BranchSubjects.RemoveRange(p);
            await context.SaveChangesAsync();
            var d = await context.Subjects.FindAsync(id);
             context.Subjects.Remove(d);
            await context.SaveChangesAsync();
            return ("Deleted Successfully");
        }

        public async Task<string> DeleteBranchConnection(int sid, int bid)
        {
            var t=await context.BranchSubjects.FirstOrDefaultAsync(n=> n.SubjectId==sid && n.BranchId == bid);
            if (t != null)
            {
                context.BranchSubjects.Remove(t);
                await context.SaveChangesAsync();
                return ("Connection deleted successfully");
            }
            else
                return ("No Such Connection found");
        }

        public async Task<List<BranchDTO>> GetBranches(int subid)
        {
            var d = await context.BranchSubjects.Where(n=> n.SubjectId==subid).ToListAsync();
            List<BranchDTO> bb = new List<BranchDTO>();
            if(d.Count>0)
            {
                foreach(var f in d)
                {
                    var g = await context.Branches.FirstOrDefaultAsync(n => n.Id == f.BranchId);
                    var f1 = new BranchDTO()
                    {
                        Id = g.Id,
                        Name = g.Name
                    };
                    bb.Add(f1);
                }
            }
            return (bb);
        }

        public async Task<IEnumerable<Subject>> Getsub()
        {
            var d = await context.Subjects.ToListAsync();
            return (d);
        }
    }
}
