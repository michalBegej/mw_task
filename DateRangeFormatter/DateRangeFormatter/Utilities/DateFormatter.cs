using System;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class DateFormatter : IDateFormatter
    {
        private readonly IValidatorManager validatorManager;
        private readonly IPrinter printer;
        private readonly IFormatter formatter;

        public DateFormatter(
            IFormatter formatter,
            IValidatorManager validatorManager,
            IPrinter printer)
        {
            this.formatter = formatter;
            this.validatorManager = validatorManager;
            this.printer = printer;
        }

        public void WriteFormatedRange()
        {
            try
            {
                this.validatorManager.RunAllValidations();
                this.printer.Print(this.GetFormatedRange());
            }
            catch (ArgumentException e)
            {
                this.printer.PrintError(e.Message);
            }
        }

        private string GetFormatedRange()
        {
            return this.formatter.FormatData();
        }        
    }
}
