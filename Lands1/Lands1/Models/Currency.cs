//debe agregarse el nuget Newtonsoftjson en el proj compartido solamente
namespace Lands1.Models
{
    using Newtonsoft.Json;

    public class Currency
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }
}
