using System.Collections.Generic;
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
        private DataManager _dataManager;

        [SetUp]
        public void SetUp()
        {
            _apiEndpoint = "testapiendpoint";
            _mockDataService = new Mock<IDataService>();
            _dataManager = new DataManager(_mockDataService.Object);
        }

        [Test]
        public void GetData_WillReturnEmptyIEnumerable()
        {
            // arrange
            var emptyEnumerable = Enumerable.Empty<User>();
            _mockDataService.Setup(x => x.GetData<User>(It.IsAny<string>()))
                .Returns(emptyEnumerable);

            // act
            var result = _dataManager.GetData<User>(_apiEndpoint);

            // assert
            Assert.AreEqual(emptyEnumerable, result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetData_WillReturnValidIEnumerable(int id)
        {
            // arrange
            var testingUser = new User
            {
                Id = id
            };
            var validData = new List<User>()
            {
                testingUser
            };
            _mockDataService.Setup(x => x.GetData<User>(It.IsAny<string>()))
                .Returns(validData);

            // act
            var result = _dataManager.GetData<User>(_apiEndpoint);

            // assert
            Assert.AreEqual(validData, result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(id, result.First().Id);
        }
    }
}
