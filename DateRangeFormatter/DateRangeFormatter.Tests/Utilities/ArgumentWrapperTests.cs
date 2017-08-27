using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateRangeFormatter.Tests.Utilities
{
    [TestClass()]
    public class ArgumentWrapperTests
    {
        private IValidatorManager validationManager;
        private IApplicationArguments applicationArgs;
        private IPrinter printer;
        private IEnvironment environment;

        [TestInitialize]
        public void Initialize()
        {
            this.validationManager = Substitute.For<IValidatorManager>();
            this.applicationArgs = Substitute.For<IApplicationArguments>();
            this.printer = Substitute.For<IPrinter>();
            this.environment = Substitute.For<IEnvironment>();
        }

        [TestMethod]
        public void ShouldCloseApplicationWhenValidationDidNotPass()
        {           
            validationManager.When(x=>x.RunAllValidations()).Do(x=> {throw new ArgumentException("error");});

            try
            {
                var argumentWrapper = new ArgumentWrapper(validationManager, applicationArgs, printer, environment);
            }
            catch (ArgumentException e)
            {
                this.printer.Received().PrintError(Arg.Is<string>(s=>s.Equals("error")));
                this.environment.Received().Exit(Arg.Is<int>(c=>c.Equals(1)));
            }            
        }

        [TestMethod]
        public void ShouldSetStartAndEndDateWhenArgumentsAreValid()
        {
            CultureHelper.SetCultureInfoEn_Us();

            this.applicationArgs.Args.Returns(new[] {"03/02/2017", "03/05/2017"});
            var expectedStartDate = new DateTime(2017, 3, 2);
            var expectedEndDate = new DateTime(2017, 3, 5);

            var argumentWrapper = new ArgumentWrapper(validationManager, applicationArgs, printer, environment);

            validationManager.Received().RunAllValidations();
            environment.DidNotReceive().Exit(Arg.Any<int>());

            Assert.AreEqual(expectedStartDate.Date, argumentWrapper.StartDate.Date);
            Assert.AreEqual(expectedEndDate.Date, argumentWrapper.EndDate.Date);
        }
    }
}