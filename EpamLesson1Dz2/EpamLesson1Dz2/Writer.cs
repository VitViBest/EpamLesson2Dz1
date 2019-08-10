using EpamLesson1Dz2.Interfaces;
using System;

namespace EpamLesson1Dz2
{
    /// <summary>
    /// Output in console.
    /// </summary>
    class ConsoleWriter : IWriter
    {
        public ConsoleWriter(ConsoleColor background,ConsoleColor textColor)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = textColor;
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
