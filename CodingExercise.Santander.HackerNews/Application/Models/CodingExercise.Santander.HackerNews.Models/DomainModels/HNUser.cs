namespace CodingExercise.Santander.HackerNews.Models.DomainModels
{
    public class HNUser
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Karma { get; set; }

        public string AboutHtml { get; set; }

        public int Submitted { get; set; }
    }
}
