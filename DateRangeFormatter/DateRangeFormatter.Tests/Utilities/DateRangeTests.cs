using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateRangeFormatter.Tests.Utilities
{
    [TestClass()]
    public class DateRangeTests
    {
        private IArgumentWrapper argumentWrapper;

        [TestInitialize]
        public void Initialize()
        {            
            this.argumentWrapper = Substitute.For<IArgumentWrapper>();
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenMonthAndYearIsTheSameCulturUs()
        {
            this.argumentWrapper.StartDate.Returns(new DateTime(2017, 5, 12));
            this.argumentWrapper.EndDate.Returns(new DateTime(2017, 5, 20));            
            var expectedDate = "12-20/05/2017";

            ActAndAssertForDiffrentCulture(expectedDate);
        }

        [TestMethod]
        public void ShouldReturCorrectFormatWhenYearAreTheSameCultureUs()
        {
            this.argumentWrapper.StartDate.Returns(new DateTime(2017, 4, 12));
            this.argumentWrapper.EndDate.Returns(new DateTime(2017, 5, 12));            
            var expectedDate = "12/04-12/05/2017";

            ActAndAssertForDiffrentCulture(expectedDate);
        }

        [TestMethod]
        public void ShouldReturnCorrectFormatWhenDayMonthYearAreDiffrentCultureUs()
        {
            this.argumentWrapper.StartDate.Returns(new DateTime(2017, 4, 12));
            this.argumentWrapper.EndDate.Returns(new DateTime(2018, 5, 12));
            
            var expectedDate = "12/04/2017-12/05/2018";

            ActAndAssertForDiffrentCulture(expectedDate);
        }

        private void ActAndAssertForDiffrentCulture(string expectedDate)
        {
            CultureHelper.SetCultureInfoEn_Us();
            var dateRangeEnUs = new DateRangeFromatter(this.argumentWrapper);

            CultureHelper.SetCultureInfoPl_PL();
            var dateRangePl = new DateRangeFromatter(this.argumentWrapper);

            Assert.AreEqual(expectedDate, dateRangeEnUs.FormatData());
            Assert.AreEqual(expectedDate, dateRangePl.FormatData());
        }
    }
}