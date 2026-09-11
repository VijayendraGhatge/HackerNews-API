using ErrorOr;

namespace CodingExercise.Santander.HackerNews.BusinessServices.Exceptions.BusinessErrors
{
    public static class AllBusinessErrors
    {
        public static class BusinessValidationErrors
        {
            public static Error DataValidation => Error.Validation(code: "DataValidation.TopCount", description: "Invalid Top Count passed.");
        }

        public static class AllDataErrors
        {
            public static Error EmptyData => Error.NotFound(code: "Data.Empty", description: "No best stories found.");
        }
    }
}
