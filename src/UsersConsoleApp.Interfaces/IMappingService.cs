using System.Collections.Generic;

namespace UsersConsoleApp.Interfaces
{
    public interface IMappingService
    {
        IEnumerable<T> ValidateAndMappingJsonData<T>(string data);
    }
}
