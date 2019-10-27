using System;

namespace Kutokasta.Console.IO
{
    internal interface IConsoleWrapper
    {
        void WriteLine(string text);
        ConsoleKeyInfo ReadKey();
    }
    
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        public ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }
    }
}