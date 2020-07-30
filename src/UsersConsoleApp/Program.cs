using System;
using System.Configuration;
using System.Linq;
using Unity;
using UsersConsoleApp.Core;
using UsersConsoleApp.Domain;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiEndpoint = ConfigurationManager.AppSettings["SourceApiEndpoint"];
            var firstQuestionId = ConfigurationManager.AppSettings["FirstQuestionId"];
            var secondQuestionAge = ConfigurationManager.AppSettings["SecondQuestionAge"];

            using (var container = UnityConfig.GetConfiguredContainer())
            {
                var dataManager = new DataManager(container.Resolve<IDataService>(), container.Resolve<ICachingService>());
                var userManager = new UserManager(container.Resolve<IUserService>());

                var success = dataManager.GetData<User>(apiEndpoint);

                if (success)
                {
                    int.TryParse(firstQuestionId, out int id);
                    Console.WriteLine($"The users full name for id={id}: {userManager.GetUserFullName(id)}");

                    int.TryParse(secondQuestionAge, out int age);
                    Console.WriteLine($"All the users first names (comma separated) who are {age}: {userManager.GetUsersFirstName(age, ",")}");

                    var numberOfGendersPerAge = userManager.GetNumberOfGenderGroupByAge();
                    numberOfGendersPerAge.ToList().ForEach(s =>
                    {
                        Console.WriteLine($"Age: {s.Age} Female: {s.Female} Male: {s.Male}");
                    });
                }
                else
                {
                    Console.WriteLine("The api endpoint is down or invalid data source.");
                }
            }

            Console.ReadLine();
        }
    }
}
