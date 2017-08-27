using System;
using System.Globalization;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class ArgumentWrapper : IArgumentWrapper
    {
        private readonly IPrinter printer;
        private readonly IEnvironment environment;

        public ArgumentWrapper(
            IValidatorManager validationManager, 
            IApplicationArguments applicationArguments,
            IPrinter printer, 
            IEnvironment environment)
        {
            this.printer = printer;
            this.environment = environment;

            try
            {                
                validationManager.RunAllValidations();

                this.StartDate = DateTime.Parse(applicationArguments.Args[0], CultureInfo.CurrentCulture);
                this.EndDate = DateTime.Parse(applicationArguments.Args[1], CultureInfo.CurrentCulture);
            }
            catch (ArgumentException e)
            {
                this.printer.PrintError(e.Message);
                this.environment.Exit(1);
            }
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
