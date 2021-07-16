using QuizApp.Domain.Entities.Classes;
using QuizApp.Domain.Entities.Db;
using QuizApp.Helpers;
using System;

namespace QuizApp.Services.Services
{
    public class QuizService
    {
        public TextHelper textHelper { get; set; }
        public QuizService()
        {
            textHelper = new TextHelper();
        }
        public void TakeQuiz(Student student)
        {
            foreach (Question question in InMemoryDb.Questions)
            {
                textHelper.TextGenerator(question.Description, ConsoleColor.Yellow, ConsoleColor.DarkYellow);
                for (int i = 1; i <= question.Answers.Count; i++)
                {
                    textHelper.TextGenerator($"{i} - {question.Answers[i - 1]}", ConsoleColor.Yellow, ConsoleColor.DarkYellow);
                }
                bool isAnswered = false;
                while (!isAnswered)
                {
                    textHelper.TextGenerator("Enter answer", ConsoleColor.Yellow, ConsoleColor.DarkYellow);
                    bool isValid = int.TryParse(Console.ReadLine(), out int selection);
                    if (!isValid)
                    {
                        textHelper.TextGenerator("You must enter a number !", ConsoleColor.Red, ConsoleColor.DarkRed);
                        continue;
                    }
                    if (selection < 1 && selection > 4)
                    {
                        textHelper.TextGenerator("Invalid selection", ConsoleColor.Red, ConsoleColor.DarkRed);
                        continue;
                    }
                    if (question.CorrectAnswer == selection)
                    {
                        student.CorrectAnswers++;
                    }
                    isAnswered = true;
                }
            }
            student.HasFinishedQuiz = true;
            textHelper.TextGenerator("Done !", ConsoleColor.Green, ConsoleColor.DarkGreen);
        }
    }
}
