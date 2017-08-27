using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class DateFormatter : IDateFormatter
    {
        private readonly IPrinter printer;
        private readonly IFormatter formatter;

        public DateFormatter(
            IFormatter formatter,
            IPrinter printer)
        {
            this.formatter = formatter;            
            this.printer = printer;
        }

        public void WriteFormatedRange()
        {                            
            this.printer.Print(this.GetFormatedRange());
        }

        private string GetFormatedRange()
        {
            return this.formatter.FormatData();
        }        
    }
}
