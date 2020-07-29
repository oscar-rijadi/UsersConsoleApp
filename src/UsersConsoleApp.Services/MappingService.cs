using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UsersConsoleApp.Interfaces;
using System.Linq;

namespace UsersConsoleApp.Services
{
    public class MappingService : IMappingService
    {
        public IEnumerable<T> ValidateAndMappingJsonData<T>(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
