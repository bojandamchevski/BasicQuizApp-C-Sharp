using QuizApp.Domain.Entities.Classes;
using QuizApp.Helpers;
using QuizApp.Services.Services;
using System;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            QuizService quizService = new QuizService();
            TextHelper textHelper = new TextHelper();

            while (true)
            {
                try
                {
                    textHelper.TextGenerator("Enter username", ConsoleColor.Blue, ConsoleColor.DarkBlue);
                    string username = Console.ReadLine();
                    if (String.IsNullOrEmpty(username))
                    {
                        throw new Exception("You must enter username");
                    }

                    Teacher teacher = userService.GetTeacherByUserName(username);
                    if (teacher != null)
                    {
                        bool passwordsMatch = userService.PasswordsMatch(teacher.Password);
                        if (!passwordsMatch)
                        {
                            throw new Exception("Password did not match 3 times. try again after 30 minutes");
                        }

                        foreach (Student student in userService.GetStudentsThatDidTheQuiz())
                        {
                            textHelper.TextGenerator($"{student.FirstName} {student.LastName} {student.CorrectAnswers}", ConsoleColor.Green, ConsoleColor.DarkGreen);
                        }

                        foreach (Student student in userService.GetStudentsThatDidNotFinishTheQuiz())
                        {
                            textHelper.TextGenerator($"{student.FirstName} {student.LastName} {student.CorrectAnswers}", ConsoleColor.Red, ConsoleColor.DarkRed);
                        }
                    }
                    else
                    {
                        Student student = userService.GetStudentByUserName(username);
                        if (student == null)
                        {
                            throw new Exception("The user does not exist");
                        }
                        bool passwordsMatch = userService.PasswordsMatch(student.Password);
                        if (!passwordsMatch)
                        {
                            throw new Exception("Password did not match 3 times. Try again after 30 minutes");
                        }
                        if (student.HasFinishedQuiz)
                        {
                            throw new Exception("You already did the quiz");
                        }
                        quizService.TakeQuiz(student);
                    }

                }
                catch (Exception e)
                {
                    textHelper.TextGenerator("Error", ConsoleColor.Red, ConsoleColor.DarkRed);
                    textHelper.TextGenerator($"{e}", ConsoleColor.Red, ConsoleColor.DarkRed);
                }
            }
        }
    }
}
