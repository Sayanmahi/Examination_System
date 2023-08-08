using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class TempMark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }  
        public int SubId { get;set; }
        [ForeignKey("SubId")]
        public Subject Subject { get; set; }
        public int QuesId { get; set; }
        [ForeignKey("QuesId")]
        public Question Question { get; set; }  
        public int Marks { get; set; }
    }
}
