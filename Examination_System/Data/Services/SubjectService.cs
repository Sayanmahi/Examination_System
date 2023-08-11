using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
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
                foreach(var k in name.BranchIds)
                {
                    var p = new BranchSubject()
                    {
                        SubjectId = c.Id,
                        BranchId = k

                    };
                    await context.AddAsync(p);
                    await context.SaveChangesAsync();

                }
                return ("Subject Added Successfully");
            }
        }
        public async Task<string> Delete(int id)
        {
            var d = await context.Subjects.FindAsync(id);
             context.Subjects.Remove(d);
            await context.SaveChangesAsync();
            return ("Deleted Successfully");
        }

        public async Task<IEnumerable<Subject>> Getsub()
        {
            var d = await context.Subjects.ToListAsync();
            return (d);
        }
    }
}
