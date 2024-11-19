using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace GitAPI.Schemas
{
    public class BaseIssue
    {
        [JsonProperty("id")]
        public Int64? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        private int? _number;
        [JsonProperty("number")]
        public int? Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        private int? _iid;
        [JsonProperty("iid")]
        public int? Iid
        {
            get
            {
                return _iid;
            }
            set
            {
                _iid = value;
                _number = value;
            }
        }

        private string _body;
        [JsonProperty("body")]
        [DisplayName("Body")]
        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                _description = value;
            }
        }

        private string _description;
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

    }
}
