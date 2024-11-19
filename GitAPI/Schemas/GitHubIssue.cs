using Newtonsoft.Json;

namespace GitAPI.Schemas
{
    public class GitHubIssue : BaseIssue
    {

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
