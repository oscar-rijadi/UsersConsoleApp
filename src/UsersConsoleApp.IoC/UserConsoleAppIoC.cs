using Unity;
using UsersConsoleApp.Interfaces;
using UsersConsoleApp.Services;

namespace UsersConsoleApp.IoC
{
    public class UserConsoleAppIoC
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<IApiService, ApiService>();
            container.RegisterType<IValidationService, ValidationService>();
            container.RegisterType<IMappingService, MappingService>();
            container.RegisterType<IUserService, UserService>();
        }
    }
}
