using System;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }

        public void PrintError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}
