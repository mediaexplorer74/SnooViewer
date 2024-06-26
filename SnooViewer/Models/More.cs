﻿using SnooViewer.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SnooViewer.Api.Models
{
    public sealed class More : IPostReplyable
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        [JsonPropertyName("children")]
        public IList<string> Children { get; set; }
    }
}
