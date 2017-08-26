using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.UnityContainer;
using Microsoft.Practices.Unity;

namespace DateRangeFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            var container = ContainerConfiguration.Configure(args);
            
            var app = container.Resolve<IApplication>();
            app.Run();
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine("Application error!");
            Environment.Exit(1);
        }
    }
}
