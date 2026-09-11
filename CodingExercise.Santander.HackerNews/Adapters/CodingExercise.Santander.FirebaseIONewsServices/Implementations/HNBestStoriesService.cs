using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.Models.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodingExercise.Santander.FirebaseIONewsServices.Implementations
{
    public class HNBestStoriesService : IHNBestStoriesService
    {
        private readonly ILogger<HNBestStoriesService> _logger;
        private readonly HackerNewsSettings _hackerNewsSettings;

        public HNBestStoriesService(ILogger<HNBestStoriesService> logger,
            IOptions<HackerNewsSettings> hackerNewsSettings)
        {
            _logger = logger;
            _hackerNewsSettings = hackerNewsSettings.Value;
        }

        public async Task<IEnumerable<HNBestStoryEntity>> GetTopNBestStoriesAsync(int topCount)
        {
            _logger.LogInformation($"HNBestStoriesService.GetTopNBestStoriesAsync() function called for Top {topCount} Best Stories.");

            List<HNBestStoryEntity> newsArticleEntities = new List<HNBestStoryEntity>();
            List<int> allBestStoryIds;
            using (var httpCli = new HttpClient())
            {
                var json = httpCli.GetStringAsync(_hackerNewsSettings.BestStoriesFileUri).Result;
                allBestStoryIds = JsonSerializer.Deserialize<List<int>>(json);
            }

            if(allBestStoryIds != null && allBestStoryIds.Any())
            {
                foreach (var storyId in allBestStoryIds.Take(topCount))
                    newsArticleEntities.Add(await FetchStoryAsync(storyId));
            }

            return newsArticleEntities;
        }

        private async Task<HNBestStoryEntity> FetchStoryAsync(int storyId)
        {
            HNBestStoryEntity storyItem = null;
            HttpClient httpClient = null;

            try
            {
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions
                {
                    AllowDuplicateProperties = false,
                    RespectNullableAnnotations = true,
                    UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
                };

                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri($"{_hackerNewsSettings.BaseUri}item/");
                string storyJson = await httpClient.GetStringAsync($"{storyId}.json");

                storyItem = JsonSerializer.Deserialize<HNBestStoryEntity>(storyJson, serializerOptions);
            }
            catch (Exception excep)
            {
                _logger.LogError($"Error encountred while fetching or deserializing the StoryId:{storyId} of HN Best Stories. Error: {excep.Message}");

                if (httpClient != null) httpClient.Dispose();
                httpClient = null;
                throw;
            }

            return storyItem;
        }
    }
}
