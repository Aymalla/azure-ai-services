using AI.Integration.APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using System.IO;
using System.Text;

namespace AI.Integration.APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisionController : ControllerBase
    {
        private readonly ILogger<TextAnalyticsController> _logger;
        private readonly ComputerVisionService _computerVisionService;

        public VisionController(ComputerVisionService computerVisionService, ILogger<TextAnalyticsController> logger)
        {
            _logger = logger;
            _computerVisionService = computerVisionService;
        }


        [HttpPost("Analyze")]
        public async Task<ApiResult> Analyze(string imageUrl)
        {
            var result = await _computerVisionService.AnalyzeAsync(imageUrl);
            return ApiResult.OK(result);
        }

    }
}
