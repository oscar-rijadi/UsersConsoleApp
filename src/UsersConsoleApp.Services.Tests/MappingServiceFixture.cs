using System.Linq;
using NUnit.Framework;
using UsersConsoleApp.Domain;

namespace UsersConsoleApp.Services.Tests
{
    [TestFixture(Category = "Unit")]
    public class MappingServiceFixture
    {
        private MappingService _mappingService;

        [SetUp]
        public void SetUp()
        {
            _mappingService = new MappingService();
        }

        [Test]
        public void ValidateAndMappingJsonData_WillReturnNullIfInputStringEmpty()
        {
            // arrange
            var input = string.Empty;

            // act
            var result = _mappingService.ValidateAndMappingJsonData<string>(input);

            // assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void ValidateAndMappingJsonData_WillReturnEmptyEnumerableIfInputStringIsNotValidJson()
        {
            // arrange
            var invalidJson = "[{\"test1\",\"test2\"]";

            // act
            var result = _mappingService.ValidateAndMappingJsonData<string>(invalidJson);

            // assert
            Assert.AreEqual(Enumerable.Empty<string>(), result);
        }

        [Test]
        [TestCase("[{ \"id\": 1},{ \"id\": 2}]", 2)]
        [TestCase("[{ \"id\": 1},{ \"id\": 2},{ \"id\": 3}]", 3)]
        public void ValidateAndMappingJsonData_WillReturnValidEnumerableIfInputStringIsValidJson(string input, int total)
        {
            // act
            var result = _mappingService.ValidateAndMappingJsonData<User>(input);

            // assert
            Assert.AreNotEqual(Enumerable.Empty<string>(), result);
            Assert.AreEqual(total, result.Count());
        }
    }
}
