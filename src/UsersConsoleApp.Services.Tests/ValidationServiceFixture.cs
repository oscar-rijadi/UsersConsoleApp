using NUnit.Framework;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class ValidationServiceFixture
    {
        private ValidationService _validationService;

        [SetUp]
        public void SetUp()
        {
            _validationService = new ValidationService();
        }

        [Test]
        public void IsJsonData_WillReturnFalseIfInvalidInput()
        {
            // arrange
            var input = string.Empty;

            // act
            var result = _validationService.IsJsonData(input);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsJsonData_WillReturnTrueIfValidInput()
        {
            // arrange
            var input = "[{ \"id\": 1},{ \"id\": 2}]";

            // act
            var result = _validationService.IsJsonData(input);

            // assert
            Assert.AreEqual(true, result);
        }
    }
}
