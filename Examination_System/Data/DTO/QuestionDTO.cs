namespace Examination_System.Data.DTO
{
    public class QuestionDTO
    {
        public string Title { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectId { get; set; }
        public int WrongMark { get; set; }
        public int CorrectMark { get; set; }
        public int SubId { get; set; }
    }
}
