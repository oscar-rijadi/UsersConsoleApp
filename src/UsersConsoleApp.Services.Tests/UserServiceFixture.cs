using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UsersConsoleApp.Domain;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class UserServiceFixture
    {
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [Test]
        public void GetUserFullName_WillReturnEmptyStringIfIdIsNotExist()
        {
            // arrange
            var testId = 1;
            var testUser = new User
            {
                Id = 2,
                FirstName = "TestFirstName",
                LastName = "TestLastName"
            };
            var data = new List<User>()
            {
                testUser
            };

            // act
            var result = _userService.GetUserFullName(data, testId);

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetUserFullName_WillReturnValidFullNameIfIdIsExist()
        {
            // arrange
            var testId = 1;
            var testUser = new User
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName"
            };
            var data = new List<User>()
            {
                testUser
            };

            // act
            var result = _userService.GetUserFullName(data, testId);

            // assert
            Assert.AreEqual($"{testUser.FirstName} {testUser.LastName}", result);
        }

        [Test]
        public void GetUsersFirstName_WillReturnEmptyStringIfAgeIsNotExist()
        {
            // arrange
            var testAge = 1;
            var testUser = new User
            {
                Age = 2
            };
            var data = new List<User>()
            {
                testUser
            };

            // act
            var result = _userService.GetUsersFirstName(data, testAge, ",");

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetUsersFirstName_WillReturnCommaSeparatedStringIfAgeIsExist()
        {
            // arrange
            var testAge = 1;
            var testUser1 = new User
            {
                Age = 1,
                FirstName = "TestFirstName1"
            };
            var testUser2 = new User
            {
                Age = 1,
                FirstName = "TestFirstName2"
            };
            var data = new List<User>()
            {
                testUser1, testUser2
            };

            // act
            var result = _userService.GetUsersFirstName(data, testAge, ",");

            // assert
            Assert.AreEqual($"{testUser1.FirstName},{testUser2.FirstName}", result);
        }

        [Test]
        public void GetNumberOfGenderGroupByAge_WillReturnEmptyEnumerableIfInputIsEmptyEnumerable()
        {
            // arrange
            var data = Enumerable.Empty<User>();

            // act
            var result = _userService.GetNumberOfGenderGroupByAge(data);

            // assert
            Assert.AreEqual(Enumerable.Empty<User>(), result);
        }

        [Test]
        public void GetNumberOfGenderGroupByAge_WillReturnValidEnumerableIfInputIsValidEnumerable()
        {
            // arrange
            var testUser1 = new User
            {
                Age = 1,
                Gender = "M"
            };
            var testUser2 = new User
            {
                Age = 1,
                Gender = "F"
            };
            var testUser3 = new User
            {
                Age = 1,
                Gender = "F"
            };
            var testUser4 = new User
            {
                Age = 2,
                Gender = "M"
            };
            var data = new List<User>()
            {
                testUser1, testUser2, testUser3, testUser4
            };

            // act
            var result = _userService.GetNumberOfGenderGroupByAge(data);

            // assert
            Assert.AreNotEqual(Enumerable.Empty<User>(), result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.First().Age);
            Assert.AreEqual(2, result.First().Female);
        }
    }
}
