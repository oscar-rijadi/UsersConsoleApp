using System;
using NUnit.Framework;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class ApiServiceFixture
    {
        private ApiService _apiService;

        [SetUp]
        public void SetUp()
        {
            _apiService = new ApiService();
        }

        [Test]
        public void GetData_WillReturnValidStringIfApiEndpointIsValid()
        {
            // arrange
            var validApiEndoint = "https://f43qgubfhf.execute-api.ap-southeast-2.amazonaws.com/sampletest";

            // act
            var result = _apiService.GetData(validApiEndoint);

            // assert
            Assert.AreNotEqual(string.Empty, result);
        }

        [Test]
        public void GetData_WillThrowUriFormatExceptionIfApiEndpointIsInvalid()
        {
            // arrange
            var validApiEndoint = string.Empty;

            // act and assert
            Assert.Throws<UriFormatException>(() => _apiService.GetData(validApiEndoint));
        }
    }
}
