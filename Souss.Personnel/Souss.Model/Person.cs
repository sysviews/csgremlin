using Newtonsoft.Json;

namespace Souss.Model
{
    public class Person
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }
    }
}
