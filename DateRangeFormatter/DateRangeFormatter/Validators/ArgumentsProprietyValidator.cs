using System;
using System.Globalization;
using System.Linq;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Validators
{
    public class ArgumentsProprietyValidator : IValidator
    {
        private readonly IApplicationArguments arguments;

        public ArgumentsProprietyValidator(IApplicationArguments arguments)
        {
            this.arguments = arguments;
        }

        public int Index => 1;

        public void Validate()
        {
            ValidateFormatCorrectness();

            ValidateArguments();
        }

        private void ValidateFormatCorrectness()
        {
            foreach (var arg in this.arguments.Args.Where(arg => !IsDateTime(arg)))
            {
                throw new ArgumentException($"Argument: {arg} is not valid date");
            }
        }

        private void ValidateArguments()
        {
            var dt1 = DateTime.Parse(this.arguments.Args[0], CultureInfo.CurrentCulture);
            var dt2 = DateTime.Parse(this.arguments.Args[1], CultureInfo.CurrentCulture);

            if (dt1.Date.Equals(dt2.Date))
            {
                throw new ArgumentException("Dates should be diffrent");
            }

            if (dt1.Date > dt2.Date)
            {
                throw new ArgumentException("Dates should be given ascending");
            }           
        }

        private static bool IsDateTime(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
        }
    }
}