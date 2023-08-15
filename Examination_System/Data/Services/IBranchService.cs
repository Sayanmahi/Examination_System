using Examination_System.Data.DTO;
using Examination_System.Models;

namespace Examination_System.Data.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> Getbranch();
        Task<string> Add(AddBranchDTO name);
        Task<string> Delete(int id);
        Task<string> AddSubjectConnection(int sid, int bid);
        Task<string> DeleteSubjectConnection(int sid, int bid);
        Task<List<DisplaySubjectsDTO>> GetSubjects(int branid);
    }
}
