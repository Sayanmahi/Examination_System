using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Examination_System.Data.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext db;
        private IConfiguration _config;
        public UserService(AppDbContext _db, IConfiguration config)
        {
            db = _db;
            _config = config;

        }

        public async Task<string> Login(LoginDTO d)
        {
            var f=await  db.Users.FirstOrDefaultAsync(n => n.Email==d.Email && n.Password==d.Password);
            if (f.IsActive == 2)
            {
                return ("Inactive");
            }
            else if (f.IsActive == 0)
                return ("Not Approved");
            else if (f != null)
            {
                var jw = JwtGenerate(f.Email, f.Type, f.Id,f.BranchsId);
                return (jw);
            }
            else
                return ("Not");
        }
        public async Task<string> AdminLogin(LoginDTO d)
        {
            var f= await db.Users.FirstOrDefaultAsync(n=>n.Email==d.Email && n.Password==d.Password);
            if (f != null)
            {
                var jw=JwtGenerate(f.Email,f.Type, f.Id,f.BranchsId);   
                return (jw);
            }
            else
            {
                return ("Not"); 
            }
        }

        public async Task<string> Register(UserDTO d)
        {
            var f=db.Users.FirstOrDefault(n=>n.Email==d.Email || n.Phone==d.Phone);
            if (f != null)
            {
                return ("Exists");
            }
            var o = new User()
            {
                Name = d.Name,
                Email = d.Email,
                Phone=d.Phone,
                Password = d.Password,
                Type = "Student",
                InstId=d.InstId,
                IsActive=0,
                BranchsId=d.BranchId
            };
            await db.Users.AddAsync(o);
            await db.SaveChangesAsync();
            return ("Done");
        }
        private string JwtGenerate(string email, string role, int userid,int bid)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256); //security key is public key so hashing security key
            var claims = new[]//dismantling the payload datas
            {
                 new Claim("Email",email),
                 new Claim("UserId",userid.ToString()),
                 new Claim("BranchId",bid.ToString()),
                 new Claim(ClaimTypes.Role,role)
                };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<string> AdminAprroval(int id)
        {
            var d=await db.Users.FirstOrDefaultAsync(n=> n.Id==id);
            if(d!=null)
            {
                d.IsActive = 1;
                await db.SaveChangesAsync();
                return ("Approved");
            }
            return ("Not");

        }
        public async Task<string> AdminDenial(int id)
        {
            var d = await db.Users.FirstOrDefaultAsync(n => n.Id == id);
            if (d != null)
            {
                d.IsActive = 2;
                await db.SaveChangesAsync();
                return ("Denied");
            }
            return ("Not");
        }

        public async Task<string> UserRequestAgain(string ema)
        {
            var d=await db.Users.FirstOrDefaultAsync(n=> n.Email==ema);
            if(d!=null)
            {
                if (d.IsActive == 2)
                {
                    d.IsActive = 0;
                    await db.SaveChangesAsync();
                    return ("Placed for reverification");
                }
                else if (d.IsActive == 1)
                {
                    return ("Already Verified");
                }
                else
                    return ("Wait for verification");
            }
            return ("Not Found");
        }

        public async Task<string> Teacherlogin(LoginDTO d)
        {
            var g= await db.Teachers.FirstOrDefaultAsync(n=> n.Email==d.Email && n.Password==d.Password);
            if (g != null)
            {
                //var f = await db.Subjects.FirstOrDefaultAsync(n => n.Id == g.SubId);
                var a = JwtGenerateTeacher(d.Email, "Teacher", g.Id);
                return (a);
            }
            else
                return ("Not");
        }
        private string JwtGenerateTeacher(string email, string role, int userid)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256); //security key is public key so hashing security key
            var claims = new[]//dismantling the payload datas
            {
                 new Claim("Email",email),
                 new Claim("UserId",userid.ToString()),
                 //new Claim("DeptName",deptname),
                 new Claim(ClaimTypes.Role,role)
                };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<List<UserdisplayapproveDTO>> Useraskingapproval()
        {
            var d= await db.Users.Where(n=> n.Type=="Student" && n.IsActive==0).ToListAsync();
            List<UserdisplayapproveDTO> dd = new List<UserdisplayapproveDTO>();
            foreach (var u in d) 
            {
                var inst = await db.Institutes.FirstOrDefaultAsync(n => n.Id == u.InstId);
                var bran = await db.Branches.FirstOrDefaultAsync(n => n.Id == u.BranchsId);
                var f = new UserdisplayapproveDTO()
                {
                    id = u.Id,
                    name = u.Name,
                    institute = inst.Name,
                    branch = bran.Name
                };
                dd.Add(f);
            }
            return dd;
        }
    }
}
