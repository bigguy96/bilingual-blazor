using Newtonsoft.Json;

namespace LocalizationApp.Entities
{
    public class RefTop
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool IsApplication { get; set; }
    }
}
