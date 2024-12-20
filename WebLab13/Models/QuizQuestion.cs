namespace WebLab13.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int CorrectAnswer { get; set; }
        public int UserAnswer { get; set; }
    }
}
