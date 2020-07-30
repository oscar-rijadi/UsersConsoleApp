using System.Collections.Generic;
using UsersConsoleApp.Domain;

namespace UsersConsoleApp.Interfaces
{
    public interface IUserService
    {
        string GetUserFullName(int id);

        string GetUsersFirstName(int age, string stringSeparator);

        IEnumerable<UserGenderByAge> GetNumberOfGenderGroupByAge();
    }
}
