using Newtonsoft.Json;

namespace LocalizationApp.Entities
{
    public class RefFooter
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool IsApplication { get; set; }
    }
}
