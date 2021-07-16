using System;

namespace QuizApp.Helpers
{
    public class TextHelper
    {
        public void TextGenerator(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine($"{text}\n");

            Console.ResetColor();
        }
    }
}
