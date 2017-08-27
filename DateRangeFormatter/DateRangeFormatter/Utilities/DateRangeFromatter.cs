using System.Globalization;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class DateRangeFromatter : IFormatter
    {
        private readonly IArgumentWrapper argumentWrapper;

        public DateRangeFromatter(IArgumentWrapper argumentWrapper)
        {
            this.argumentWrapper = argumentWrapper;
        }

        private bool AreTheSameMonth()
        {
            return argumentWrapper.StartDate.Month.Equals(argumentWrapper.EndDate.Month);
        }

        private bool AreTheSameYear()
        {
            return argumentWrapper.StartDate.Year.Equals(argumentWrapper.EndDate.Year);
        }


        public string FormatData()
        {

            if (AreTheSameYear() && AreTheSameMonth())
            {
                return $"{argumentWrapper.StartDate.ToString("dd", CultureInfo.InvariantCulture)}-{argumentWrapper.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}";
            }

            if (AreTheSameYear())
            {
                return $"{argumentWrapper.StartDate.ToString("dd/MM", CultureInfo.InvariantCulture)}-{argumentWrapper.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}";
            }

            return $"{argumentWrapper.StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}-{argumentWrapper.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}";
        }
    }
}