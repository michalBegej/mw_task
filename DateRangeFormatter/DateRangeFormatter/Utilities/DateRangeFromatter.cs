using System;
using System.Globalization;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class DateRangeFromatter : IFormatter
    {        
        private readonly IApplicationArguments applicationArguments;

        public DateRangeFromatter(IApplicationArguments applicationArguments)
        {
            this.applicationArguments = applicationArguments;            
        }

        private static bool AreTheSameMonth(DateTime startDate, DateTime endTime)
        {
            return startDate.Month.Equals(endTime.Month);
        }

        private static bool AreTheSameYear(DateTime startDate, DateTime endDate)
        {
            return startDate.Year.Equals(endDate.Year);
        }
        

        public string FormatData()
        {
            var startDate = DateTime.Parse(applicationArguments.Args[0], CultureInfo.CurrentCulture);
            var endDate = DateTime.Parse(applicationArguments.Args[1], CultureInfo.CurrentCulture);

            if (AreTheSameYear(startDate,endDate) 
                && AreTheSameMonth(startDate, endDate))
            {
                return $"{startDate.ToString("dd")}-{endDate.ToString("dd/MM/yyyy")}".Replace('.', '/');
            }

            if (AreTheSameYear(startDate, endDate))
            {
                return $"{startDate.ToString("dd/MM")}-{endDate.ToString("dd/MM/yyyy")}".Replace('.', '/');
            }

            return  $"{startDate.ToString("dd/MM/yyyy")}-{endDate.ToString("dd/MM/yyyy")}".Replace('.', '/');
        }        
    }
}