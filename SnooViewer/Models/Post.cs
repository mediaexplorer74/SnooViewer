﻿using SnooViewer.Common.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

#nullable enable

namespace SnooViewer.Api.Models
{
    public sealed class Post : IVotable, ICreated
    {
        [JsonPropertyName("author_flair_background_color")]
        public string AuthorFlairBackgroundColor { get; set; }

        [JsonPropertyName("approved_at_utc")]
        [JsonConverter(typeof(UtcTimestampConverter))]
        public DateTime ApprovedAtUtc { get; set; }

        [JsonPropertyName("subreddit")]
        public string Subreddit { get; set; }

        [JsonPropertyName("selftext")]
        public string Selftext { get; set; }

        [JsonPropertyName("user_reports")]
        public JsonArray UserReports { get; set; }

        [JsonPropertyName("user_reports_dismissed")]
        public JsonArray DismissedUserReports { get; set; }

        [JsonPropertyName("saved")]
        public bool? Saved { get; set; }

        [JsonPropertyName("mod_reason_title")]
        public string ModReasonTitle { get; set; }

        [JsonPropertyName("gilded")]
        public int? Gilded { get; set; }

        [JsonPropertyName("clicked")]
        public bool? Clicked { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("link_flair_richtext")]
        public JsonArray LinkFlairRichText { get; set; }

        [JsonPropertyName("subreddit_name_prefixed")]
        public string SubredditNamePrefixed { get; set; }

        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; }

        [JsonPropertyName("pwls")]
        public int? Pwls { get; set; }

        [JsonPropertyName("link_flair_css_class")]
        public string LinkFlairCssClass { get; set; }

        [JsonPropertyName("downs")]
        public int Downs { get; set; }

        [JsonPropertyName("thumbnail_height")]
        public int? ThumbnailHeight { get; set; }

        [JsonPropertyName("top_awarded_type")]
        public string TopAwardedType { get; set; }

        [JsonPropertyName("parent_whitelist_status")]
        public string ParentWhitelistStatus { get; set; }

        [JsonPropertyName("hide_score")]
        public bool? HideScore { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quarantine")]
        public bool? Quarantine { get; set; }

        [JsonPropertyName("link_flair_text_color")]
        public string LinkFlairTextColor { get; set; }

        [JsonPropertyName("upvote_ratio")]
        public double UpvoteRatio { get; set; }

        [JsonPropertyName("ignore_reports")]
        public bool? IgnoreReports { get; set; }

        [JsonPropertyName("ups")]
        public int Ups { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("thumbnail_width")]
        public int? ThumbnailWidth { get; set; }

        [JsonPropertyName("author_flair_template_id")]
        public string AuthorFlairTemplateId { get; set; }

        [JsonPropertyName("is_original_content")]
        public bool? IsOriginalCntent { get; set; }

        [JsonPropertyName("author_fullname")]
        public string AuthorFullname { get; set; }

        [JsonPropertyName("is_reddit_media_domain")]
        public bool? IsRedditMediaDomain { get; set; }

        [JsonPropertyName("is_meta")]
        public bool? IsMeta { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("link_flair_text")]
        public string LinkFlairText { get; set; }

        [JsonPropertyName("can_mod_post")]
        public bool? CanModPost { get; set; }

        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("approved_by")]
        public string? ApprovedBy { get; set; }

        [JsonPropertyName("is_created_from_ads_ui")]
        public bool? IsCreatedFromAdsUI { get; set; }

        [JsonPropertyName("author_premium")]
        public bool? AuthorPremium { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("edited")]
        [JsonConverter(typeof(LocalTimestampConverter))]
        public DateTime Edited { get; set; }

        [JsonPropertyName("author_flair_css_class")]
        public string AuthorFlairCssClass { get; set; }

        [JsonPropertyName("author_flair_richtext")]
        public JsonArray AuthorFlairRichText { get; set; }

        [JsonPropertyName("post_hint")]
        public string PostHint { get; set; }

        [JsonPropertyName("content_categories")]
        public object ContentCategories { get; set; }

        [JsonPropertyName("is_self")]
        public bool IsSelf { get; set; }

        [JsonPropertyName("subreddit_type")]
        public string SubredditType { get; set; }

        [JsonPropertyName("created")]
        [JsonConverter(typeof(LocalTimestampConverter))]
        public DateTime Created { get; set; }

        [JsonPropertyName("link_flair_type")]
        public string LinkFlairType { get; set; }

        [JsonPropertyName("wls")]
        public int? Wls { get; set; }

        [JsonPropertyName("removed_by_category")]
        public object RemovedByCategory { get; set; }

        [JsonPropertyName("banned_by")]
        public object BannedBy { get; set; }

        [JsonPropertyName("author_flair_type")]
        public string AuthorFlairType { get; set; }

        [JsonPropertyName("total_awards_received")]
        public int? TotalAwardsReceived { get; set; }

        [JsonPropertyName("allow_live_comments")]
        public bool? AllowLiveComments { get; set; }

        [JsonPropertyName("selftext_html")]
        public string SelfTextHtml { get; set; }

        [JsonPropertyName("likes")]
        public bool? Likes { get; set; }

        [JsonPropertyName("suggested_sort")]
        public string SuggestedSort { get; set; }

        [JsonPropertyName("banned_at_utc")]
        [JsonConverter(typeof(UtcTimestampConverter))]
        public DateTime BannedAtUtc { get; set; }

        [JsonPropertyName("url_overridden_by_dest")]
        public string UrlOverridenByDest { get; set; }

        [JsonPropertyName("view_count")]
        public int? ViewCount { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("no_follow")]
        public bool? NoFollow { get; set; }

        [JsonPropertyName("spam")]
        public bool Spam { get; set; }

        [JsonPropertyName("is_crosspostable")]
        public bool IsCrosspostable { get; set; }

        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }

        [JsonPropertyName("over_18")]
        public bool Over18 { get; set; }

        [JsonPropertyName("preview")]
        public Preview Preview { get; set; }

        [JsonPropertyName("all_awardings")]
        public JsonArray AllAwardings { get; set; }

        [JsonPropertyName("awarders")]
        public JsonArray Awarders { get; set; }

        [JsonPropertyName("media_only")]
        public bool MediaOnly { get; set; }

        [JsonPropertyName("link_flair_template_id")]
        public string LinkFlairTemplateId { get; set; }

        [JsonPropertyName("can_gild")]
        public bool CanGild { get; set; }

        [JsonPropertyName("removed")]
        public bool Removed { get; set; }

        [JsonPropertyName("spoiler")]
        public bool Spoiler { get; set; }

        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("author_flair_text")]
        public string? AuthorFlairText { get; set; }

        [JsonPropertyName("treatment_tags")]
        public JsonArray TreatmentTags { get; set; }

        [JsonPropertyName("visited")]
        public bool Visited { get; set; }

        [JsonPropertyName("removed_by")]
        public object RemovedBy { get; set; }

        [JsonPropertyName("mod_note")]
        public string ModNote { get; set; }

        [JsonPropertyName("distinguished")]
        public string? Distinguished { get; set; }

        [JsonPropertyName("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonPropertyName("author_is_blocked")]
        public bool AuthorIsBlocked { get; set; }

        [JsonPropertyName("mod_reason_by")]
        public string ModReasonBy { get; set; }

        [JsonPropertyName("num_reports")]
        public int? NumReports { get; set; }

        [JsonPropertyName("removal_reason")]
        public string? RemovalReason { get; set; }

        [JsonPropertyName("link_flair_background_color")]
        public string LinkFlairBackgroundColor { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("num_duplicates")]
        public int? NumDuplicates { get; set; }

        [JsonPropertyName("report_reasons")]
        public JsonArray ReportReasons { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("discussion_type")]
        public object DiscussionType { get; set; }

        [JsonPropertyName("num_comments")]
        public int NumComments { get; set; }

        [JsonPropertyName("send_replies")]
        public bool SendReplies { get; set; }

        [JsonPropertyName("media")]
        public object Media { get; set; }

        [JsonPropertyName("contest_mode")]
        public bool ContestMode { get; set; }

        [JsonPropertyName("author_patreon_flair")]
        public bool AuthorPatreonFlair { get; set; }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        [JsonPropertyName("author_flair_text_color")]
        public object AuthorFlairTextColor { get; set; }

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("whitelist_status")]
        public string WhitelistStatus { get; set; }

        [JsonPropertyName("stickied")]
        public bool Stickied { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("subreddit_subscribers")]
        public int? SubredditSubscribers { get; set; }

        [JsonPropertyName("created_utc")]
        [JsonConverter(typeof(UtcTimestampConverter))]
        public DateTime CreatedUtc { get; set; }

        [JsonPropertyName("num_crossposts")]
        public int? NumCrossposts { get; set; }

        [JsonPropertyName("mod_reports")]
        public IReadOnlyList<object> ModReports { get; set; }

        [JsonPropertyName("is_video")]
        public bool IsVideo { get; set; }

        [JsonPropertyName("is_gallery")]
        public bool? IsGallery { get; set; }

        [JsonPropertyName("media_metadata")]
        public Dictionary<string, ImageContainer> MediaMetadata { get; set; }
    }
}
