namespace CodingExercise.Santander.HackerNews.Models.DomainModels
{
    public class HNBestStory
    {
        public string Title { get; set; }

        public string Uri { get; set; }

        public string PostedBy { get; set; }

        public DateTime PostedOn { get; set; }

        public int Score { get; set; }

        public int NumberOfComments { get; set; }
    }
}
