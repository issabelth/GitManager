using Newtonsoft.Json;
using System;

namespace GitAPI.Schemas
{
    public class GitLabIssue
    {
        [JsonProperty("id")]
        public Int64? Id { get; set; }

        [JsonProperty("iid")]
        public int? Iid { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
