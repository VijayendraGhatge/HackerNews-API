using System.Text.Json.Serialization;

namespace CodingExercise.Santander.FirebaseIONewsServices.Models
{
    public class HNUserEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public long CreatedUnixTime { get; set; }

        [JsonIgnore]
        public DateTime CreatedUtc =>
            DateTimeOffset.FromUnixTimeSeconds(CreatedUnixTime).UtcDateTime;

        [JsonPropertyName("karma")]
        public int Karma { get; set; }

        [JsonPropertyName("about")]
        public string? AboutHtml { get; set; } = null;

        [JsonPropertyName("submitted")]
        public int[]? Submitted { get; set; } = null;
    }
}
