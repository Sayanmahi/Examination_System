using Microsoft.EntityFrameworkCore.Storage;

namespace Examination_System.Models
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
        public int SubjectId { get; set; } 
        public Subject Subjects { get; set; }
    }
}
