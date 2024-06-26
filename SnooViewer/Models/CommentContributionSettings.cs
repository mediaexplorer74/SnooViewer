﻿using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SnooViewer.Models.Api
{
    public sealed class CommentContributionSettings
    {
        [JsonPropertyName("allowed_media_types")]
        public JsonArray? AllowedMediaTypes { get; set; }
    }
}
