using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.Models.DomainModels;

namespace CodingExercise.Santander.FirebaseIONewsServices.Mapper
{
    public class HNUserMapper : IMapper<HNUserEntity, HNUser>
    {
        public IEnumerable<HNUser> MapListToDTOList(IEnumerable<HNUserEntity> sourceList)
        {
            throw new NotImplementedException();
        }

        public HNUser MapToDTO(HNUserEntity source)
        {
            return new HNUser 
            { 
                Id = source.Id,
                CreatedAt = source.CreatedUtc,
                Karma = source.Karma,
                AboutHtml = string.IsNullOrWhiteSpace(source.AboutHtml) ? string.Empty : source.AboutHtml,
                Submitted = source.Submitted != null && source.Submitted.Any()? source.Submitted.Length : 0,
            };
        }
    }
}
