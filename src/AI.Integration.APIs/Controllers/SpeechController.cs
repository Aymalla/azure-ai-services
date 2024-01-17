using AI.Integration.APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using System.IO;
using System.Text;

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

            var sb = new StringBuilder();
            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                if (cancellation.Reason == CancellationReason.Error)
                {
                    sb.AppendLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    sb.AppendLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    sb.AppendLine($"CANCELED: Did you update the subscription info?");
                }
            }

            return ApiResult.OK(result);
        }
    }
}
