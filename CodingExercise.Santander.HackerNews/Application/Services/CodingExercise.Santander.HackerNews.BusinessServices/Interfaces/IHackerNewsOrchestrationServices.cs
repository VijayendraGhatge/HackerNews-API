using CodingExercise.Santander.HackerNews.Models.DomainModels;
using ErrorOr;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Interfaces
{
    public interface IHackerNewsOrchestrationServices
    {
        Task<ErrorOr<IEnumerable<HNBestStory>>> GetTopNBestStories(int topNoOfBestStories);
    }
}
