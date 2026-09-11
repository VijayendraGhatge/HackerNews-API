using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.BusinessErrors;
using CodingExercise.Santander.HackerNews.BusinessServices.Interfaces;
using CodingExercise.Santander.HackerNews.Models.DomainModels;
using ErrorOr;
using Microsoft.Extensions.Logging;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Implementations
{
    public class HackerNewsOrchestrationServices : IHackerNewsOrchestrationServices
    {
        private readonly ILogger<HackerNewsOrchestrationServices> _logger;
        private readonly IHNBestStoriesService _newsProviderService;
        private readonly IMapper<HNBestStoryEntity, HNBestStory> _bestStoryMapper;

        public HackerNewsOrchestrationServices(ILogger<HackerNewsOrchestrationServices> logger,
            IHNBestStoriesService newsProviderService,
            IMapper<HNBestStoryEntity, HNBestStory> bestStoryMapper)
        {
            _logger = logger;
            _newsProviderService = newsProviderService;
            _bestStoryMapper = bestStoryMapper;
        }

        public async Task<ErrorOr<IEnumerable<HNBestStory>>> GetTopNBestStories(int topNoOfBestStories)
        {
            if (topNoOfBestStories <= 0)
                return AllBusinessErrors.BusinessValidationErrors.DataValidation;

            IEnumerable<HNBestStoryEntity> hNBestStoryEntities = await _newsProviderService.GetTopNBestStoriesAsync(topNoOfBestStories);
            if (hNBestStoryEntities == null)
                return AllBusinessErrors.AllDataErrors.EmptyData;

            List<HNBestStory> hNBestStories = _bestStoryMapper.MapListToDTOList(hNBestStoryEntities).ToList();

            return hNBestStories;
        }
    }
}
