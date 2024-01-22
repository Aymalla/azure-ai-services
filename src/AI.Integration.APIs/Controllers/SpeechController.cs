using AI.Integration.APIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AI.Integration.APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechController : ControllerBase
    {
        private readonly ILogger<TextAnalyticsController> _logger;
        private readonly SpeechService _speechService;

        public SpeechController(SpeechService speechService, ILogger<TextAnalyticsController> logger)
        {
            _logger = logger;
            _speechService = speechService;
        }


        [HttpPost("translate")]
        public async Task<ApiResult> Translate(IFormFile formFile)
        {
            var filePath = Path.GetTempFileName() + ".wav";
            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            var result = await _speechService.TranslateAsync(filePath);
            System.IO.File.Delete(filePath);
            return ApiResult.OK(result);
        }

        [HttpPost("recognize")]
        public async Task<ApiResult> RecognizeSpeech(IFormFile formFile)
        {
            var filePath = Path.GetTempFileName() + ".wav";
            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            var result = await _speechService.RecognizeSpeechAsync(filePath);
            System.IO.File.Delete(filePath);
            return ApiResult.OK(result);
        }
    }
}
