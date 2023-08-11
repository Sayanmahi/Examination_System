namespace Examination_System.Models
{
    public class BranchSubject
    {
        public int Id { get; set; } 
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
