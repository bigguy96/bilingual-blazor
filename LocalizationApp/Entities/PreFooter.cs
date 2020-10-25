using Newtonsoft.Json;

namespace LocalizationApp.Entities
{
    public class PreFooter
    {
        public string CdnEnv { get; set; }
        public string VersionIdentifier { get; set; }
        public string DateModified { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool ShowShare { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool ShowFeedback { get; set; }
        public bool ShowPostContent { get; set; }
    }
}
