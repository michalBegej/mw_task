using System;
using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class EnvironmentControl : IEnvironment
    {
        public void Exit(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}