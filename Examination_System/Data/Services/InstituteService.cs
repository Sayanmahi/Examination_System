using Examination_System.Data.DTO;
using Examination_System.Migrations;
using Examination_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System;
using System.Net;

namespace Examination_System.Data.Services
{
    public class InstituteService : IInstituteService
    {
        private readonly AppDbContext appDbContext;
        public InstituteService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<string> AddInst(InstDTO inst)
        {
            var d=await appDbContext.Institutes.FirstOrDefaultAsync(n=> n.Name.ToLower()==inst.Name.ToLower());
            if(d!=null)
            {
                return ("Institute already exists");
            }
            else
            {
                var f = new Institute()
                {
                    Name = inst.Name,
                    Address = inst.Address,
                    City = inst.City,
                    Region = inst.Region,
                    PostalCode = inst.PostalCode,
                    Phone = inst.Phone
                };
                await appDbContext.Institutes.AddAsync(f);
                await appDbContext.SaveChangesAsync();
                return ("Institute Created");
            }
        }

        public async Task<string> AddTeacher(TeacherDTO tt)
        {
            var d = new Teacher()
            {
                Name = tt.Name,
                Phone = tt.Phone,
                Email = tt.Email,
                InstId = tt.Instid,
                SubId = tt.Subid,
                Password=tt.Password
            };
            await appDbContext.Teachers.AddAsync(d);
            await appDbContext.SaveChangesAsync();
            return ("Teacher added Successfully");
        }

        public async Task<string> DeleteTeacher(int id)
        {
            var d=await appDbContext.Teachers.FirstOrDefaultAsync(n=> n.Id==id);
            if(d!=null)
            {
                appDbContext.Remove(d);
                await appDbContext.SaveChangesAsync();
                return ("Deleted Successfully");
            }
            else
            {
                return ("Something went wrong");
            }
        }

        public async Task<List<Institute>> GetAll()
        {
            var d= await appDbContext.Institutes.ToListAsync();
            return (d);
        }

        public async Task<Institute> GetInstByid(int id)
        {
            var d = await appDbContext.Institutes.FirstOrDefaultAsync(n => n.Id == id);
            return (d);
        }

        public async Task<string> UpdateInst(int id,InstDTO inst)
        {
            var d = await appDbContext.Institutes.FirstOrDefaultAsync(n => n.Id == id);
            if(d!=null)
            {
                d.Name = inst.Name;
                d.Address = inst.Address;
                d.City = inst.City;
                d.Region = inst.Region;
                d.PostalCode = inst.PostalCode;
                d.Phone = inst.Phone;
                await appDbContext.SaveChangesAsync();
                return ("Update Successfull");
            }
            return ("Something went worng");
        }
    }
}
