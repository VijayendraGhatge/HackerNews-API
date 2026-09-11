using CodingExercise.Santander.FirebaseIONewsServices.Models;

namespace CodingExercise.Santander.FirebaseIONewsServices.Interfaces
{
    public interface IHNBestStoriesService
    {
        Task<IEnumerable<HNBestStoryEntity>> GetTopNBestStoriesAsync(int topCount);
    }
}
