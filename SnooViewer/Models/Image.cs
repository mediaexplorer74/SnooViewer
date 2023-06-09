using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SnooViewer.Api.Models
{
    public sealed class Image
    {
        [JsonPropertyName("u")]
        public string Url { get; set; }

        [JsonPropertyName("x")]
        public int? Width { get; set; }

        [JsonPropertyName("y")]
        public int? Height { get; set; }
    }

    public sealed class PreviewImage
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }
    }

    public record Preview(
        //TODO
        //[property: JsonPropertyName("images")] IReadOnlyList<PreviewImage> Images,
        //[property: JsonPropertyName("enabled")] bool? Enabled
    );
}
