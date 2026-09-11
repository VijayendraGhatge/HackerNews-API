using System.Net;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.ApplicationErrors
{
    public abstract class AppError : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public AppError(
            string message,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
