using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateRangeFormatter.Tests.Utilities
{
    [TestClass]
    public class DateFormatterTests
    {        
        private IPrinter printer;
        private IFormatter formatter;

        [TestInitialize]
        public void Initialize()
        {            
            this.formatter = Substitute.For<IFormatter>();            
            this.printer = Substitute.For<IPrinter>();
        }

        [TestMethod]
        public void ShouldCallPrintMethodWithCorrectArguments()
        {
            CultureHelper.SetCultureInfoEn_Us();

            this.formatter.FormatData().Returns("01/01/2017-03/02/2018");

            var dataFormatter = new DateFormatter(this.formatter, this.printer);
            dataFormatter.WriteFormatedRange();

            this.formatter.Received().FormatData();
            this.printer.Received().Print(Arg.Is<string>(x=>x.Equals("01/01/2017-03/02/2018")));
        }
    }
}