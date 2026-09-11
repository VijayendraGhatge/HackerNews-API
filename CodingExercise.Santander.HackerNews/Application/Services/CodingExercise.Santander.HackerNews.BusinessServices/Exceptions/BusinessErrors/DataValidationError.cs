namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.BusinessErrors
{
    public sealed class DataValidationError : BusinessError
    {
        public DataValidationError(string errorMessage) : base (errorMessage) {}
    }
}
