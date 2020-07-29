using Newtonsoft.Json;

namespace UsersConsoleApp.Domain
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("first")]
        public string FirstName { get; set; }
        [JsonProperty("last")]
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return !string.IsNullOrEmpty(FirstName) 
                    ? $"{FirstName.Trim()} {LastName}"
                    : LastName.Trim();
            }
        }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
    }
}
