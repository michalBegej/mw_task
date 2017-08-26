using System;
using System.Collections.Generic;
using System.Linq;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class ValidatorManager : IValidatorManager
    {
        private readonly IEnumerable<IValidator> validators;

        public ValidatorManager(IValidator[] validators)
        {
            this.validators = validators.OrderBy(v=>v.Index);
        }

        public void RunAllValidations()
        {
            foreach (var validator in this.validators)
            {
                try
                {
                    validator.Validate();
                }
                catch (ArgumentException e)
                {
                    throw;
                }
            }
        }
    }
}
