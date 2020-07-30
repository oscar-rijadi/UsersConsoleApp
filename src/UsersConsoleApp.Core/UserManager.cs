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

        public string GetUserFullName(int id)
        {
            return _userService.GetUserFullName(id);
        }

        public string GetUsersFirstName(int age, string stringSeparator)
        {
            return _userService.GetUsersFirstName(age, stringSeparator);
        }

        public IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge()
        {
            return _userService.GetNumberOfGenderGroupByAge();
        }
    }
}
