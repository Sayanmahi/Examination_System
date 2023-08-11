using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Subject
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual List<BranchSubject> BrancheSubjects { get; set; }


    }
}
