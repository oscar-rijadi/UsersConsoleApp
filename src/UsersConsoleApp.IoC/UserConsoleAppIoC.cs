using Unity;
using Unity.Injection;
using Unity.Lifetime;
using UsersConsoleApp.Interfaces;
using UsersConsoleApp.Services;
using UsersConsoleApp.Services.Cache;

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
            container.RegisterType<ICachingService>(
                new InjectionFactory((unityContainer, type, arg3) => new CachingService(MemoryCacheFactory.Instance.DefaultCache)));
        }
    }
}
