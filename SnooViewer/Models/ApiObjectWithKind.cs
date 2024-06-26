﻿using System.Text.Json.Serialization;

namespace SnooViewer.Api.Models
{
    public class ApiObjectWithKind<T>
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("data")]
        public virtual T Data { get; set; }
    }

    public class ApiObjectWithKind : ApiObjectWithKind<object>
    {
        [JsonPropertyName("data")]
        public override object Data { get; set; }
    }
}
