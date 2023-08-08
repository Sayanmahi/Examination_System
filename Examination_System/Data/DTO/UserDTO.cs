using Examination_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Data.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public int InstId { get; set; }
        public int BranchId { get; set; }
        public int IsActive { get; set; }
    }
}
