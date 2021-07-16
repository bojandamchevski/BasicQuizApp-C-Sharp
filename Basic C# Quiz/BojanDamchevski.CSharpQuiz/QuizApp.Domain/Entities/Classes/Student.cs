using QuizApp.Domain.Entities.Enums;

namespace QuizApp.Domain.Entities.Classes
{
    public class Student : User
    {
        public bool HasFinishedQuiz { get; set; }
        public int CorrectAnswers { get; set; }
        public Student()
        {
            UserRole = Role.Student;
        }
    }
}
