using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Data.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext db;
        public UserService(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<string> Register(UserDTO d)
        {
            var o = new User()
            {
                Name = d.Name,
                Email = d.Email,
                Phone=d.Phone,
                Password = d.Password,
                Type = d.Type,
                InstId=d.InstId,
                IsActive=0
            };
            await db.Users.AddAsync(o);
            await db.SaveChangesAsync();
            return ("Done");
        }

    }
}
