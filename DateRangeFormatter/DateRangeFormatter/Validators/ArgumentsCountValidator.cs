using System;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Validators
{
    public class ArgumentsCountValidator : IValidator
    {
        private readonly IApplicationArguments arguments;

        public ArgumentsCountValidator(IApplicationArguments arguments)
        {
            this.arguments = arguments;
        }

        public int Index => 0;

        public void Validate()
        {
            ValidateArgumentsCount();
        }

        private void ValidateArgumentsCount()
        {
            if (this.arguments.Args.Length != 2)
            {
                throw new ArgumentException("The application accepts 2 parameters");
            }
        }
        
    }
}
