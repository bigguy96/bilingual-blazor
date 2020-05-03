using Newtonsoft.Json;

namespace LocalizationApp.Entities
{
    public class AppFooter
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool ShowFooter { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool ShowFeatures { get; set; }
    }
}
