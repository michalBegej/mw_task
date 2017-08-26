using DateRangeFormatter.Interfaces;

namespace DateRangeFormatter.Utilities
{
    public class CommandLineArguments : IApplicationArguments
    {
        public CommandLineArguments(string[] args)
        {
            this.Args = args;
        }

        public string[] Args { get; }
    }
}
