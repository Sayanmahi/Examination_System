using Examination_System.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Data.Services
{
    public interface IUserService
    {
        Task<string> Register(UserDTO d);
        Task<string> Login(LoginDTO d);
        Task<string> AdminLogin(LoginDTO d);
        Task<string> AdminAprroval(int id);
        Task<string> AdminDenial(int id);
        Task<string> UserRequestAgain(string ema);
        Task<string> Teacherlogin(LoginDTO d);
        Task<List<UserdisplayapproveDTO>> Useraskingapproval();
        //Task<string> TeacherAdd(UserDTO d);
    }
}
