using Examination_System.Models;

namespace Examination_System.Data.DTO
{
    public class TeacherDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Instid { get; set; }
        public int Subid { get; set; }
        public string Password { get; set; }
    }
}
