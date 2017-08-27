using System;

namespace DateRangeFormatter.Interfaces
{
    public interface IArgumentWrapper
    {
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }
}