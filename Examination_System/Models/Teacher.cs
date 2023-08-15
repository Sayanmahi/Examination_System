using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get;set; }
        public string Email { get; set; }
        [ForeignKey("Institutes")]
        public int InstId { get; set; }
        public Institute Institutes { get; set; }
        [ForeignKey("Subjects")]
        public int SubId { get; set; }
        public Subject Subjects { get; set; }
        public string Password { get; set; }
    }
}
