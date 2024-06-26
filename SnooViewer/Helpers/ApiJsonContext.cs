﻿using SnooViewer.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SnooViewer.Api
{
    [JsonSerializable(typeof(More))]
    [JsonSerializable(typeof(Message))]
    [JsonSerializable(typeof(Post))]
    [JsonSerializable(typeof(Comment))]
    [JsonSerializable(typeof(User))]
    [JsonSerializable(typeof(IDictionary<string, string>))]
    [JsonSerializable(typeof(TokenInfo))]
    [JsonSerializable(typeof(IList<Listing<IList<ApiObjectWithKind<Comment>>>>))]
    [JsonSerializable(typeof(Listing<IList<ApiObjectWithKind<Post>>>))]
    [JsonSerializable(typeof(Listing<IList<ApiObjectWithKind<Message>>>))]
    [JsonSerializable(typeof(ApiObjectWithKind<Subreddit>))]
    [JsonSerializable(typeof(ApiObjectWithKind<User>))]
    public sealed partial class ApiJsonContext : JsonSerializerContext
    {
    }
}
