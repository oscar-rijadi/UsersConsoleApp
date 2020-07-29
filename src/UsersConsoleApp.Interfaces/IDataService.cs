using System.Collections.Generic;

namespace UsersConsoleApp.Interfaces
{
    public interface IDataService
    {
        IEnumerable<T> GetData<T>(string apiEndpoint);
    }
}
