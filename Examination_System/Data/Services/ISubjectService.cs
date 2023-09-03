using Examination_System.Data.DTO;
using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace Examination_System.Data.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> Getsub();
        Task<string> Add(SubjectDTO name);
        Task<string> Delete(int id);
        Task<string> AddBranchConnection(int sid, int bid);
        Task<string> DeleteBranchConnection(int sid, int bid);
        Task<List<BranchDTO>> GetBranches(int branid);

    }
}
