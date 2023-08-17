using System.Xml.Schema;

namespace Examination_System.Data.DTO
{
    public class ResultDTO
    {
        public string SubjectName{get;set;}
        public int MarksGot { get; set; }
        public int TotalMarks { get; set; }
        public decimal SubjectPercentage { get; set; }
        public string Status { get; set; }

    }
}
