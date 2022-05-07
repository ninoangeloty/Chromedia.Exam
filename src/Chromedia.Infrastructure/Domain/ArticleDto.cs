using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chromedia.Infrastructure.Domain
{
    public class Article
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("data")]
        public ArticleDetail[] Data { get; set; }
    }

    public class ArticleDetail
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("num_comments")]
        public int? NumberOfComments { get; set; }
        [JsonProperty("story_id")]
        public int? StoryId { get; set; }
        [JsonProperty("story_title")]
        public string StoryTitle { get; set; }
        [JsonProperty("story_url")]
        public string StoryUrl { get; set; }
        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
    }
}
