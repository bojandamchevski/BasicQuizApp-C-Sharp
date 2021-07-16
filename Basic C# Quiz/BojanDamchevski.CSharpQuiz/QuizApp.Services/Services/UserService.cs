using QuizApp.Domain.Entities.Classes;
using QuizApp.Domain.Entities.Db;
using QuizApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Services.Services
{
    public class UserService
    {
        public TextHelper textHelper { get; set; }
        public UserService()
        {
            textHelper = new TextHelper();
        }
        public Student GetStudentByUserName(string username)
        {
            return InMemoryDb.Students.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }
        public Teacher GetTeacherByUserName(string username)
        {
            return InMemoryDb.Teachers.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }
        public List<Student> GetStudentsThatDidTheQuiz()
        {
            return InMemoryDb.Students.Where(x => x.HasFinishedQuiz).ToList();
        }
        public List<Student> GetStudentsThatDidNotFinishTheQuiz()
        {
            return InMemoryDb.Students.Where(x => !x.HasFinishedQuiz).ToList();
        }
        public bool PasswordsMatch(string password)
        {
            for (int i = 0; i < 3; i++)
            {
                textHelper.TextGenerator("Enter password", ConsoleColor.Blue, ConsoleColor.DarkBlue);
                string passwordInput = Console.ReadLine();
                if (password == passwordInput)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
