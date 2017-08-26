using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DateRangeFormatter.Interfaces;
using DateRangeFormatter.Utilities;
using NSubstitute;

namespace DateRangeFormatter.Tests
{
    [TestClass()]
    public class ValidatorManagerTests
    {
        private IValidator validator1;
        private IValidator validator2;

        [TestInitialize]
        public void Initialize()
        {
            this.validator1 = Substitute.For<IValidator>();
            this.validator2 = Substitute.For<IValidator>();

            validator1.Index.Returns(0);
            validator2.Index.Returns(1);
        }
        [TestMethod]
        public void ShouldCallValidateMethodForAllValidators()
        {
            //Act
            var validationManager = new ValidatorManager(new [] {validator2, validator1});

            validationManager.RunAllValidations();

            //Assert
            Received.InOrder(() =>
            {
                validator1.Validate();
                validator2.Validate();
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenOneValidationIsIncorrect()
        {
            //Arrange
            validator2.When(x=>x.Validate()).Do(x=> {throw new ArgumentException("ex");});

            //Act
            var validationManager = new ValidatorManager(new[] { validator2, validator1 });
            validationManager.RunAllValidations();

        }
    }
}