using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace GitAPI.Schemas
{
    public class Issue
    {
        [JsonProperty("id")]
        public Int64? Id { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        [DisplayName("Description")]
        public string Body { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
