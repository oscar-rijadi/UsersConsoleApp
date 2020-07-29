using System.Collections.Generic;
using UsersConsoleApp.Domain;

namespace UsersConsoleApp.Interfaces
{
    public interface IUserService
    {
        string GetUserFullName(IEnumerable<User> data, int id);

        string GetUsersFirstName(IEnumerable<User> data, int age, string stringSeparator);

        IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge(IEnumerable<User> data);
    }
}
