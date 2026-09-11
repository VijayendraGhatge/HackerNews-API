using System.Net;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.ApplicationErrors
{
    public sealed class FileNotFoundError : AppError
    {
        public FileNotFoundError(
            string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, statusCode)
        {
        }
    }
}
