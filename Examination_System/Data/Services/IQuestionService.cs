using Examination_System.Data.DTO;
using Examination_System.Models;

namespace Examination_System.Data.Services
{
    public interface IQuestionService
    {
        Task<string> AddQues(QuestionDTO q);
        Task<string> DeleteQues(int id);
        Task<string> Modify(int id, QuestionDTO q);
        Task<List<Question>> GetQuestionBysubId(int id);
        Task<Question> GetQuestionbyId(int id);

    }
}
