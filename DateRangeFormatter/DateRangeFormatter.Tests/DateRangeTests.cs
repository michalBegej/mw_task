using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Utilities;
using NSubstitute;

namespace DateRangeFormatter.Tests
{
    [TestClass()]
    public class DateRangeTests
    {
        private IApplicationArguments applicationArguments;

        [TestInitialize]
        public void Initialize()
        {
            this.applicationArguments = Substitute.For<IApplicationArguments>();
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenMonthAndYearIsTheSameCulturUs()
        {
            this.applicationArguments.Args.Returns(new[] {"05/12/2017", "05/20/2017"});
            var expectedDate = "12-20/05/2017";

            ActAndAssertForCultureInfo_Us(expectedDate);
        }

        [TestMethod]
        public void ShouldReturCorrectFormatWhenYearAreTheSameCultureUs()
        {            
            this.applicationArguments.Args.Returns(new[] { "04/12/2017", "05/12/2017" });
            var expectedDate = "12/04-12/05/2017";

            ActAndAssertForCultureInfo_Us(expectedDate);
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenDayMonthYearAreDiffrentCultureUs()
        {            
            this.applicationArguments.Args.Returns(new[] { "04/12/2017", "05/12/2018" });
            var expectedDate = "12/04/2017-12/05/2018";

            ActAndAssertForCultureInfo_Us(expectedDate);
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenMonthAndYearIsTheSameCulturePl()
        {
            this.applicationArguments.Args.Returns(new[] { "12/05/2017", "20/05/2017" });
            var expectedDate = "12-20/05/2017";

            ActAndAssertForCultureInfo_Pl(expectedDate);
        }

        [TestMethod]
        public void ShouldReturCorrectFormatWhenYearAreTheSameCulturePl()
        {
            this.applicationArguments.Args.Returns(new[] { "12/04/2017", "12/05/2017" });
            var expectedDate = "12/04-12/05/2017";

            ActAndAssertForCultureInfo_Pl(expectedDate);
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenDayMonthYearAreDiffrentCulturePl()
        {
            this.applicationArguments.Args.Returns(new[] { "12/04/2017", "12/05/2018" });
            var expectedDate = "12/04/2017-12/05/2018";

            ActAndAssertForCultureInfo_Pl(expectedDate);
        }

        private void ActAndAssertForCultureInfo_Us(string expectedDate)
        {
            CultureHelper.SetCultureInfoEn_Us();
            var dateRangeEnUs = new DateRangeFromatter(this.applicationArguments);
                        
            Assert.AreEqual(expectedDate, dateRangeEnUs.FormatData());            
        }

        private void ActAndAssertForCultureInfo_Pl(string expectedDate)
        {
            CultureHelper.SetCultureInfoPl_PL();
            var dateRangePl = new DateRangeFromatter(this.applicationArguments);

            Assert.AreEqual(expectedDate, dateRangePl.FormatData());            
        }
    }
}