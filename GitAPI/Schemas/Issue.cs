using Newtonsoft.Json;
using System.ComponentModel;

namespace GitAPI.Schemas
{
    public class Issue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        [DisplayName("Description")]
        public string Body { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
