using Newtonsoft.Json;

namespace GitAPI.Schemas
{
    public class GitLabIssue : BaseIssue
    {

        [JsonProperty("iid")]
        public int? Iid { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
