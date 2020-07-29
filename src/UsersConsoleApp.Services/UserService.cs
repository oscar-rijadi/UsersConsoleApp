using System.Collections.Generic;
using System.Linq;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services
{
    public class UserService : IUserService
    {
        public string GetUserFullName(IEnumerable<User> data, int id)
        {
            var arrData = data.ToArray();
            if (arrData.FirstOrDefault(x => x.Id == id) != null)
            {
                return arrData.First(x => x.Id == id).FullName;
            }
            return string.Empty;
        }

        public string GetUsersFirstName(IEnumerable<User> data, int age, string stringSeparator)
        {
            var result = data.ToArray()
                .Where(x => x.Age == age)
                .Select(x => x.FirstName);
            return string.Join(stringSeparator, result);
        }

        public IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge(IEnumerable<User> data)
        {
            return data.ToArray()
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
