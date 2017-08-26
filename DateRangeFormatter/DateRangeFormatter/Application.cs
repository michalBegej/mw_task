using System;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter
{
    public class Application : IApplication
    {
        private readonly IDateFormatter dateFormatter;

        public Application(IDateFormatter dateFormatter)
        {
            this.dateFormatter = dateFormatter;
        }

        public void Run()
        {
            this.dateFormatter.WriteFormatedRange();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}