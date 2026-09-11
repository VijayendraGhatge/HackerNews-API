using System.Net;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.BusinessErrors
{
    public abstract class BusinessError : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public BusinessError(
            string message,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
