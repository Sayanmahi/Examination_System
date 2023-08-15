namespace Examination_System.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get;set; }
        public string Email { get; set; }
        public Institute Institute { get; set; }
        public Subject Subject { get; set; }
    }
}
