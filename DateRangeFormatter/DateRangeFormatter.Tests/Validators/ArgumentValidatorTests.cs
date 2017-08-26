using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateRangeFormatter.Tests.Validators
{
    [TestClass]
    public class ArgumentValidatorTests
    {
        private IApplicationArguments arguments;

        [TestInitialize]
        public void Initialize()
        {
            arguments = Substitute.For<IApplicationArguments>();
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenArgumentCountIsOne()
        {
            //Arrange
            arguments.Args.Returns(new[] {"param1"});

            //Act & Assert
            ActAndAssert();
        }

        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExpectionWhenArgumentCountIsThree()
        {
            //Arrange     
            arguments.Args.Returns(new[] { "param1", "param2", "param3" });

            //Act & Assert
            ActAndAssert();
        }

        [TestMethod]
        public void ShouldNotThrowExceptionWhenArgumentsCountIsTwo()
        {
            //Arrange 
            arguments.Args.Returns(new[] { "param1", "param2"});

            //Act & Assert
            ActAndAssert();
        }

        private void ActAndAssert()
        {
            var argumentsValidator = new ArgumentsCountValidator(arguments);
            argumentsValidator.Validate();
        }
    }
}