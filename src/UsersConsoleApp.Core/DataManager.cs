using UsersConsoleApp.Domain.Helpers;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Core
{
    public class DataManager
    {
        private readonly IDataService _dataService;
        private readonly ICachingService _cachingService;

        public DataManager(IDataService dataService,
            ICachingService cachingService)
        {
            _dataService = dataService;
            _cachingService = cachingService;
        }

        public bool GetData<T>(string apiEndpoint)
        {
            var result = _dataService.GetData<T>(apiEndpoint);
            if (result.IsAny())
            {
                _cachingService.Set(typeof(T).ToString(), result);
                return true;
            }
            return false;
        }
    }
}
