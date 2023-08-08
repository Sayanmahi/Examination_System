using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<User> Users { get; set; }

    }
}
