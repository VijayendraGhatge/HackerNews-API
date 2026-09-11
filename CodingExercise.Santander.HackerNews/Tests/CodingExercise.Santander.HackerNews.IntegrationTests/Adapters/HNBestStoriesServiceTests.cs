using CodingExercise.Santander.FirebaseIONewsServices.Implementations;
using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.IntegrationTests.BaseClasses;
using CodingExercise.Santander.HackerNews.Models.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CodingExercise.Santander.HackerNews.IntegrationTests.Adapters
{
    public class HNBestStoriesServiceTests : IntegrationTestBase
    {
        private IHNBestStoriesService _sut;
        private readonly HackerNewsSettings _hackerNewsSettings;

        public HNBestStoriesServiceTests() : base()
        {
            IOptions<HackerNewsSettings> hackerNewsSettingsOpt = ServiceProvider.GetRequiredService<IOptions<HackerNewsSettings>>();
            ILogger<HNBestStoriesService> logger = LoggerFactory.CreateLogger<HNBestStoriesService>();
            _hackerNewsSettings = hackerNewsSettingsOpt.Value;

            _sut = new HNBestStoriesService(logger, hackerNewsSettingsOpt);
        }

        [Fact]
        public async Task SubjectUnderTest_InitiatedOrCreatedProperly()
        {
            // Arrange, Act, Assert
            Assert.NotNull(_sut);
            Assert.IsType<HNBestStoriesService>(_sut);
            Assert.IsAssignableFrom<IHNBestStoriesService>(_sut);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task WhenGetTopNBestStoriesIsCalled_WithValidCount_AndReturnsValidBestStories(int topCount)
        {
            // Arrange
            Assert.NotNull(_sut);

            // Act
            var topNBestStories = await _sut.GetTopNBestStoriesAsync(topCount);

            // Assert
            Assert.NotNull(topNBestStories);
            Assert.IsType<List<HNBestStoryEntity>>(topNBestStories);
            List<HNBestStoryEntity> bestStories = topNBestStories.ToList();
            Assert.Equal(topCount, bestStories.Count);
            Assert.True(bestStories.All(s => s.Id > 0));
            Assert.True(bestStories.All(s => string.Equals(s.RawType, "story")));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task WhenGetTopNBestStoriesIsCalled_WithInValidCount_AndReturnsNoStories(int topCount)
        {
            // Arrange
            Assert.NotNull(_sut);

            // Act
            var topNBestStories = await _sut.GetTopNBestStoriesAsync(topCount);

            // Assert
            Assert.NotNull(topNBestStories);
            Assert.Equal(0, topNBestStories.Count());
        }
    }
}
