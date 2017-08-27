using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Utilities;
using DateRangeFormatter.Validators;
using Microsoft.Practices.Unity;

namespace DateRangeFormatter.UnityContainer
{
    public class ContainerConfiguration
    {
        private static readonly Microsoft.Practices.Unity.UnityContainer Container;
        static ContainerConfiguration()
        {
            Container = new Microsoft.Practices.Unity.UnityContainer();
        }

        public static Microsoft.Practices.Unity.UnityContainer Configure(string[] args)
        {            
            RegisterTypes(args);
            RegisterValidators();

            return Container;
        }

        private static void RegisterTypes(string[] args)
        {
            Container.RegisterType<IApplication, Application>();
            Container.RegisterInstance<IApplicationArguments>(new CommandLineArguments(args));
            
            Container.RegisterType<IValidatorManager, ValidatorManager>();
            Container.RegisterType<IPrinter, ConsolePrinter>();
            Container.RegisterType<IDateFormatter, DateFormatter>();
            Container.RegisterType<IFormatter, DateRangeFromatter>();
            Container.RegisterType<IArgumentWrapper, ArgumentWrapper>();
            Container.RegisterType<IEnvironment, EnvironmentControl>();

        }

        private static void RegisterValidators()
        {
            Container.RegisterType<IValidator, ArgumentsCountValidator>("argsCountValidator");
            Container.RegisterType<IValidator, ArgumentsProprietyValidator>("argsProprietyValidator");
        }
    }
}
