using System.Collections.Generic;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Core
{
    public class DataManager
    {
        private readonly IDataService _dataService;

        public DataManager(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<T> GetData<T>(string apiEndpoint)
        {
            return _dataService.GetData<T>(apiEndpoint);
        }
    }
}
