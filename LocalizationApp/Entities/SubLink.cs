using Newtonsoft.Json;

namespace LocalizationApp.Entities
{
    public class SubLink : Link
    {
        [JsonProperty("subhref")]
        public new string Href { get; set; }
        [JsonProperty("subtext")]
        public new string Text { get; set; }
    }
}