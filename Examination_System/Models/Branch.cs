using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BranchSubject> BranchSubjects { get; set; }


    }
}
