using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;
using System.Linq;

namespace UsersConsoleApp.Core.Tests
{
    [TestFixture(Category = "Unit")]
    public class UserManagerFixture
    {
        private List<User> _mockData;
        private Mock<IUserService> _mockUserService;
        private UserManager _userManager;

        [SetUp]
        public void SetUp()
        {
            _mockData = new List<User>();
            _mockUserService = new Mock<IUserService>();
            _userManager = new UserManager(_mockUserService.Object);
        }

        [Test]
        public void GetUserFullName_WillReturnEmptyString()
        {
            // arrange
            _mockUserService.Setup(x => x.GetUserFullName(It.IsAny<IEnumerable<User>>(), It.IsAny<int>()))
                .Returns(string.Empty);

            // act
            var result = _userManager.GetUserFullName(_mockData, 1);

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        [TestCase("testUserName1")]
        [TestCase("testUserName2")]
        [TestCase("testUserName3")]
        public void GetUserFullName_WillReturnValidString(string expected)
        {
            // arrange
            _mockUserService.Setup(x => x.GetUserFullName(It.IsAny<IEnumerable<User>>(), It.IsAny<int>()))
                .Returns(expected);

            // act
            var result = _userManager.GetUserFullName(_mockData, 1);

            // assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetUsersFirstName_WillReturnEmptyString()
        {
            // arrange
            _mockUserService.Setup(x => x.GetUsersFirstName(It.IsAny<IEnumerable<User>>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(string.Empty);

            // act
            var result = _userManager.GetUsersFirstName(_mockData, 1, ",");

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        [TestCase("test1,test2,test3")]
        [TestCase("test4,test5,test6")]
        [TestCase("test7,test8,test9")]
        public void GetUsersFirstName_WillReturnCommaSeparatedString(string expected)
        {
            // arrange
            _mockUserService.Setup(x => x.GetUsersFirstName(It.IsAny<IEnumerable<User>>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(expected);

            // act
            var result = _userManager.GetUsersFirstName(_mockData, 1, ",");

            // assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetNumberOfGenderGroupByAge_WillReturnEmptyIEnumerable()
        {
            // arrange
            var emptyEnumerable = Enumerable.Empty<UserGenderByAge>();
            _mockUserService.Setup(x => x.GetNumberOfGenderGroupByAge(It.IsAny<IEnumerable<User>>()))
                .Returns(emptyEnumerable);

            // act
            var result = _userManager.GetNumberOfGenderGroupByAge(_mockData);

            // assert
            Assert.AreEqual(emptyEnumerable, result);
        }

        [Test]
        [TestCase(20, 1)]
        [TestCase(30, 2)]
        [TestCase(40, 3)]
        public void GetNumberOfGenderGroupByAge_WillReturnValidIEnumerable(int age, int female)
        {
            // arrange
            var testingUserGenderByAge = new UserGenderByAge
            {
                Age = age,
                Female = 1,
                Male = 2
            };
            var validData = new List<UserGenderByAge>()
            {
                testingUserGenderByAge
            };
            _mockUserService.Setup(x => x.GetNumberOfGenderGroupByAge(It.IsAny<IEnumerable<User>>()))
                .Returns(validData);

            // act
            var result = _userManager.GetNumberOfGenderGroupByAge(_mockData);

            // assert
            Assert.AreEqual(validData, result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(age, result.First().Age);
        }
    }
}
