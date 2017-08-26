using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Utilities;
using NSubstitute;

namespace DateRangeFormatter.Tests
{
    [TestClass]
    public class DateFormatterTests
    {
        private IValidatorManager validationManager;
        private IPrinter printer;
        private IFormatter formatter;

        [TestInitialize]
        public void Initialize()
        {
            this.validationManager = Substitute.For<IValidatorManager>();
            this.formatter = Substitute.For<IFormatter>();            
            this.printer = Substitute.For<IPrinter>();
        }

        [TestMethod]        
        public void ShouldCallPrintErrorWhenException()
        {            
            this.validationManager.When(x=>x.RunAllValidations()).Do(x=> {throw new ArgumentException();});

            var dataformatter = new DateFormatter(this.formatter,this.validationManager, this.printer);

            dataformatter.WriteFormatedRange();

            this.printer.Received(1).PrintError(Arg.Any<string>());
        }

        [TestMethod]
        public void ShouldCallPrintMethodWithCorrectArguments()
        {
            CultureHelper.SetCultureInfoEn_Us();

            this.formatter.FormatData().Returns("01/01/2017-03/02/2018");
            var dataFormatter = new DateFormatter(this.formatter, this.validationManager, this.printer);

            dataFormatter.WriteFormatedRange();

            this.validationManager.Received().RunAllValidations();
            this.printer.Received().Print(Arg.Is<string>(x=>x.Equals("01/01/2017-03/02/2018")));
        }
    }
}