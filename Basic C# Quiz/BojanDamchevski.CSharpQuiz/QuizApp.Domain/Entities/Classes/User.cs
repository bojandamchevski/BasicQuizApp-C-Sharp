using QuizApp.Domain.Entities.Enums;

namespace QuizApp.Domain.Entities.Classes
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role UserRole { get; set; }
    }
}
