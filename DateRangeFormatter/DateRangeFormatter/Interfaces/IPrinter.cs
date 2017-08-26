namespace DateRangeFormatter.Interfaces
{
    public interface IPrinter
    {
        void Print(string data);

        void PrintError(string message);
    }
}