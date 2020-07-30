using System.Collections.Generic;
using System.Linq;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services
{
    public class UserService : IUserService
    {
        private readonly ICachingService _cachingService;

        public UserService(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        public string GetUserFullName(int id)
        {
            var arrData = ((IEnumerable<User>)_cachingService.Get(typeof(User).ToString())).ToArray();
            if (arrData.FirstOrDefault(x => x.Id == id) != null)
            {
                return arrData.First(x => x.Id == id).FullName;
            }
            return string.Empty;
        }

        public string GetUsersFirstName(int age, string stringSeparator)
        {
            var arrData = ((IEnumerable<User>)_cachingService.Get(typeof(User).ToString())).ToArray();
            var result = arrData
                .Where(x => x.Age == age)
                .Select(x => x.FirstName);
            return string.Join(stringSeparator, result);
        }

        public IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge()
        {
            var arrData = ((IEnumerable<User>)_cachingService.Get(typeof(User).ToString())).ToArray();
            return arrData
                .GroupBy(x => x.Age)
                .Select(group => new UserGenderByAge
                {
                    Age = group.Key,
                    Female = group.Count(x => x.Gender == "F"),
                    Male = group.Count(x => x.Gender == "M")
                })
                .OrderBy(x => x.Age);
        }
    }
}
