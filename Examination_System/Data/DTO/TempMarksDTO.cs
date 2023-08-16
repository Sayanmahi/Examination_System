using Examination_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Data.DTO
{
    public class TempMarksDTO
    {
        public int UserId { get; set; }
        public int SubId { get; set; }
        public int QuesId { get; set; }
        public int Option { get; set; }
    }
}
