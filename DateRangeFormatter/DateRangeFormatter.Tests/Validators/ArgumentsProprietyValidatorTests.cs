using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Tests.Helpers;
using DateRangeFormatter.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateRangeFormatter.Tests.Validators
{
    [TestClass]
    public class ArgumentsProprietyValidatorTests
    {
        private IApplicationArguments applicationArguments;

        [TestInitialize]
        public void Initialize()
        {
            applicationArguments = Substitute.For<IApplicationArguments>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenAnyOfArgumentsInIncorrect()
        {
            //Arrange
            this.applicationArguments.Args.Returns(new string[] {"02/01/2016", "abc"});

            //Act
            ActAndAssert();
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenAnyArgumenetsIsIncorrectDate()
        {
            //Arrange
            this.applicationArguments.Args.Returns(new[] { "02/01/2016", "42/13/2016" });

            //Act
            ActAndAssert();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenAnyArgumentsIsIncorrectForCultureInfoEn_US()
        {
            //Arrange
            CultureHelper.SetCultureInfoEn_Us();

            this.applicationArguments.Args.Returns(new[] { "02/30/2016", "02/13/2016" });

            //Act
            ActAndAssert();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenAnyArgumentsIsIncorrectForCultureInfoPl_PL()
        {
            //Arrange
            CultureHelper.SetCultureInfoPl_PL();

            this.applicationArguments.Args.Returns(new string[] { "31/02/2016", "26/12/2016" });

            //Act
            ActAndAssert();
        }

        [TestMethod]
        
        public void ShouldNotThrowExceptionWhenWhenBothDateAreCorrectForCultureInfoEn_us()
        {
            //Arrange
            CultureHelper.SetCultureInfoEn_Us();

            this.applicationArguments.Args.Returns(new[] { "02/11/2016", "02/13/2016" });

            //Act
            ActAndAssert();
        }        

        [TestMethod]
        public void ShouldNotThrowExceptionWhenWhenBothDateAreCorrectForCultureInfoPl_PL()
        {
            //Arrage
            CultureHelper.SetCultureInfoPl_PL();

            this.applicationArguments.Args.Returns(new[] { "20/02/2016", "02/12/2016" });

            //Act
            ActAndAssert();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenFirstDateIsLaterThanSecondOneCultureInfoPl_PL()
        {
            //Arrange
            CultureHelper.SetCultureInfoPl_PL();

            this.applicationArguments.Args.Returns(new[] {"22/02/2016", "01/02/2016"});

            //Act
            ActAndAssert();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenFirstDateIsLaterThanSecondOneCultureInfoEn_US()
        {
            //Arrange
            CultureHelper.SetCultureInfoPl_PL();

            this.applicationArguments.Args.Returns(new[] { "02/22/2016", "01/02/2016" });

            //Act
            ActAndAssert();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenArgumentsAreTheSame()
        {
            //Arrange
            CultureHelper.SetCultureInfoPl_PL();
            this.applicationArguments.Args.Returns(new[] {"12/02/2016", "12/02/2016"});

            //Act
            ActAndAssert();
        }

        private void ActAndAssert()
        {
            var argumentValidator = new ArgumentsProprietyValidator(this.applicationArguments);
            argumentValidator.Validate();
        }
        
    }
}