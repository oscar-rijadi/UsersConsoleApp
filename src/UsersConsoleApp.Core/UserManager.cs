using System.Collections.Generic;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Core
{
    public class UserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public string GetUserFullName(IEnumerable<User> data, int id)
        {
            return _userService.GetUserFullName(data, id);
        }

        public string GetUsersFirstName(IEnumerable<User> data, int age, string stringSeparator)
        {
            return _userService.GetUsersFirstName(data, age, stringSeparator);
        }

        public IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge(IEnumerable<User> data)
        {
            return _userService.GetNumberOfGenderGroupByAge(data);
        }
    }
}
