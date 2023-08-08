using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Institute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; } 


    }
}
