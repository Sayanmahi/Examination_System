using Examination_System.Data.DTO;
using Examination_System.Models;

namespace Examination_System.Data.Services
{
    public interface IInstituteService
    {
        Task<string> AddInst(InstDTO inst);
        Task<Institute> GetInstByid(int id);
        Task<List<Institute>> GetAll();
        Task<string> UpdateInst(int id,InstDTO inst);
        Task<string> AddTeacher(TeacherDTO tt);
        Task<string> DeleteTeacher(int id);
        Task<List<Subject>> ShowmysubjectsByTeacherId(int id);
        Task<string> DeleteInstitute(int id);

    }
}
