using System.Text.Json.Serialization;

namespace CodingExercise.Santander.FirebaseIONewsServices.Models
{
    public class HNBestStoryEntity
    {
        // Required
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Optional flags
        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; } = true;

        [JsonPropertyName("dead")]
        public bool? Dead { get; set; } = true;

        // Type & author
        [JsonPropertyName("type")]
        public string? RawType { get; set; } = null;

        [JsonIgnore]
        public NewsItemType? Type =>
            RawType?.ToLowerInvariant() switch
            {
                "story" => NewsItemType.Story,
                "comment" => NewsItemType.Comment,
                "job" => NewsItemType.Job,
                "poll" => NewsItemType.Poll,
                "pollopt" => NewsItemType.PollOption,
                _ => null
            };

        [JsonPropertyName("by")]
        public string? By { get; set; } = null;

        // Unix time
        [JsonPropertyName("time")]
        public long? UnixTime { get; set; } = null;

        /// <summary>
        /// Creation time in UTC, converted from Unix time.
        /// </summary>
        [JsonIgnore]
        public DateTime? CreatedUtc =>
            UnixTime.HasValue
                ? DateTimeOffset.FromUnixTimeSeconds(UnixTime.Value).UtcDateTime
                : (DateTime?)null;

        // Content
        [JsonPropertyName("text")]
        public string? TextHtml { get; set; } = null;

        [JsonPropertyName("url")]
        public string? Url { get; set; } = null;

        [JsonPropertyName("title")]
        public string? Title { get; set; } = null;

        // Relationships
        [JsonPropertyName("parent")]
        public int? ParentId { get; set; } = null;

        [JsonPropertyName("poll")]
        public int? PollId { get; set; } = null;

        [JsonPropertyName("kids")]
        public int[]? Kids { get; set; } = null;

        [JsonPropertyName("parts")]
        public int[]? Parts { get; set; } = null;

        // Scores / counts
        [JsonPropertyName("score")]
        public int? Score { get; set; } = null;

        [JsonPropertyName("descendants")]
        public int? Descendants { get; set; } = null;
    }

    public enum NewsItemType
    {
        Story,
        Comment,
        Job,
        Poll,
        PollOption
    }
}
