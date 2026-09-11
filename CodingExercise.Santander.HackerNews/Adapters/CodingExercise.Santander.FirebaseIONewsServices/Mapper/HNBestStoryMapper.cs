using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.Models.DomainModels;

namespace CodingExercise.Santander.FirebaseIONewsServices.Mapper
{
    public class HNBestStoryMapper : IMapper<HNBestStoryEntity, HNBestStory>
    {
        public IEnumerable<HNBestStory> MapListToDTOList(IEnumerable<HNBestStoryEntity> sourceList)
        {
            List<HNBestStory> newsArticles = new List<HNBestStory>();

            if (sourceList != null && sourceList.Any())
                newsArticles.AddRange(sourceList.Select(so => MapToDTO(so)));

            return newsArticles;
        }

        public HNBestStory MapToDTO(HNBestStoryEntity source)
        {
            return new HNBestStory
            {
                Title = source.Title,
                Uri = source.Url,
                PostedBy = source.By,
                PostedOn = source.UnixTime.HasValue ? source.CreatedUtc.Value : DateTime.MinValue,
                Score = source.Score.HasValue ? source.Score.Value : 0,
                NumberOfComments = source.Kids != null && source.Kids.Any() ? source.Kids.Length : 0
            };
        }
    }
}
