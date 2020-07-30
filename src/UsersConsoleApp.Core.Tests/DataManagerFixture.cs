using System.Linq;
using Moq;
using NUnit.Framework;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Core.Tests
{
    [TestFixture(Category = "Unit")]
    public class DataManagerFixture
    {
        private string _apiEndpoint;
        private Mock<IDataService> _mockDataService;
        private Mock<ICachingService> _mockCachingService;
        private DataManager _dataManager;

        [SetUp]
        public void SetUp()
        {
            _apiEndpoint = "testapiendpoint";
            _mockDataService = new Mock<IDataService>();
            _mockCachingService = new Mock<ICachingService>();
            _dataManager = new DataManager(_mockDataService.Object, _mockCachingService.Object);
        }

        [Test]
        public void GetData_WillReturnFalseIfGetEmptyEnumerable()
        {
            // arrange
            var emptyEnumerable = Enumerable.Empty<User>();
            _mockDataService.Setup(x => x.GetData<User>(It.IsAny<string>()))
                .Returns(emptyEnumerable);

            // act
            var result = _dataManager.GetData<User>(_apiEndpoint);

            // assert
            Assert.AreEqual(false, result);
        }
    }
}
