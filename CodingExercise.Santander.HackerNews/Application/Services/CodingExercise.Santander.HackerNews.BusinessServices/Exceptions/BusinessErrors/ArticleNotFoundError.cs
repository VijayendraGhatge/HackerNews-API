using System.Net;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.BusinessErrors
{
    public sealed class ArticleNotFoundError : BusinessError
    {
        public ArticleNotFoundError(
            string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message, statusCode)
        {
        }
    }
}
