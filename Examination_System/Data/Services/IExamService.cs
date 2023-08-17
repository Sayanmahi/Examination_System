using Examination_System.Data.DTO;
using Examination_System.Models;

namespace Examination_System.Data.Services
{
    public interface IExamService
    {
        Task<List<Question>> GetQuestions(int subid);
        Task StoreAns(TempMarksDTO mark);
        Task UpdateAns(TempMarksDTO mark);
        Task<string> Submit(int uid,int subid);
        Task<List<ResultDTO>> GetResults(int uid);
    }
}
