using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class DataServiceFixture
    {
        private string testApiEndpoint;
        private string testApiResult;
        private DataService _dataService;
        private Mock<IApiService> _mockApiService;
        private Mock<IValidationService> _mockValidationService;
        private Mock<IMappingService> _mockMappingService;

        [SetUp]
        public void SetUp()
        {
            testApiEndpoint = "testApiEndpoint";
            testApiResult = "testApiResult";
            _mockApiService = new Mock<IApiService>();
            _mockValidationService = new Mock<IValidationService>();
            _mockMappingService = new Mock<IMappingService>();
            _dataService = new DataService(_mockApiService.Object,
                _mockValidationService.Object,
                _mockMappingService.Object);
        }

        [Test]
        public void GetData_WillReturnEmptyEnumerableIfApiServiceReturnEmptyString()
        {
            // arrange
            _mockApiService.Setup(x => x.GetData(It.IsAny<string>())).Returns(string.Empty);

            // act
            var result = _dataService.GetData<string>(testApiEndpoint);

            // assert
            Assert.AreEqual(Enumerable.Empty<string>(), result);
        }

        [Test]
        public void GetData_WillReturnEmptyEnumerableIfIsJsonDataFalse()
        {
            // arrange
            _mockApiService.Setup(x => x.GetData(It.IsAny<string>())).Returns(testApiResult);
            _mockValidationService.Setup(x => x.IsJsonData(It.IsAny<string>())).Returns(false);

            // act
            var result = _dataService.GetData<string>(testApiEndpoint);

            // assert
            Assert.AreEqual(Enumerable.Empty<string>(), result);
        }

        [Test]
        public void GetData_WillReturnEmptyEnumerableIfValidateAndMappingJsonDataReturnsEmptyEnumerable()
        {
            // arrange
            _mockApiService.Setup(x => x.GetData(It.IsAny<string>())).Returns(testApiResult);
            _mockValidationService.Setup(x => x.IsJsonData(It.IsAny<string>())).Returns(true);
            _mockMappingService.Setup(x => x.ValidateAndMappingJsonData<string>(It.IsAny<string>()))
                .Returns(Enumerable.Empty<string>());

            // act
            var result = _dataService.GetData<string>(testApiEndpoint);

            // assert
            Assert.AreEqual(Enumerable.Empty<string>(), result);
        }

        [Test]
        public void GetData_WillReturnValidEnumerableIfValidateAndMappingJsonDataReturnsValidEnumerable()
        {
            // arrange
            var validData = new List<string>() { "test1", "test2" };
            _mockApiService.Setup(x => x.GetData(It.IsAny<string>())).Returns(testApiResult);
            _mockValidationService.Setup(x => x.IsJsonData(It.IsAny<string>())).Returns(true);
            _mockMappingService.Setup(x => x.ValidateAndMappingJsonData<string>(It.IsAny<string>()))
                .Returns(validData);

            // act
            var result = _dataService.GetData<string>(testApiEndpoint);

            // assert
            Assert.AreEqual(validData, result);
        }
    }
}
