using CodingExercise.Santander.HackerNews.BusinessServices.Interfaces;
using CodingExercise.Santander.HackerNews.Models.DomainModels;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CodingExercise.Santander.HackerNews.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HNBestStoriesController : ControllerBase
    {
        private readonly ILogger<HNBestStoriesController> _logger;
        private readonly IHackerNewsOrchestrationServices _hackerNewsOrchestrationServices;

        public HNBestStoriesController(ILogger<HNBestStoriesController> logger,
            IHackerNewsOrchestrationServices hackerNewsOrchestrationServices)
        {
            _logger = logger;
            _hackerNewsOrchestrationServices = hackerNewsOrchestrationServices;
        }

        [HttpGet("GetTopNBestStories")]
        public async Task<ErrorOr<IEnumerable<HNBestStory>>> GetTopNBestStories([FromQuery] int noOfTopBestStories)
        {
            return await _hackerNewsOrchestrationServices.GetTopNBestStories(noOfTopBestStories);
        }
    }
}
