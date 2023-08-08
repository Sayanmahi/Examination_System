using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public int InstId { get; set; }
        [ForeignKey("InstId")]
        public Institute Institute { get; set; }

    }
}
