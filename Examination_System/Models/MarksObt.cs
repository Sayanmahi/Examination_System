using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class MarksObt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int QuesId { get;set; }
        public Question Question { get; set; }
        public int Total { get; set; }
    }
}
