using QuizApp.Domain.Entities.Enums;

namespace QuizApp.Domain.Entities.Classes
{
    public class Teacher : User
    {
        public Teacher()
        {
            UserRole = Role.Teacher;
        }
    }
}
