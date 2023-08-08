using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectId { get; set; }
        public int WrongMark { get; set; }
        public int CorrectMark { get; set; }


    }
}
