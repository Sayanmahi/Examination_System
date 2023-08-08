using Examination_System.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Data.Services
{
    public interface IUserService
    {
        Task<string> Register(UserDTO d);
    }
}
