namespace CodingExercise.Santander.FirebaseIONewsServices.Interfaces
{
    public interface IMapper<TSource, TResult>
    {
        TResult MapToDTO(TSource source);

        IEnumerable<TResult> MapListToDTOList(IEnumerable<TSource> sourceList);
    }
}
