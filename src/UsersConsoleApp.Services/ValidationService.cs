using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services
{
    public class ValidationService : IValidationService
    {
        public bool IsJsonData(string data)
        {
            try
            {
                JToken.Parse(data);
                return true;
            }
            catch (JsonReaderException ex)
            {
                return false;
            }
        }
    }
}
