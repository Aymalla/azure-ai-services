using AI.Integration.APIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AI.Integration.APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TextAnalyticsController> _logger;
        private readonly TranslationService _translationService;

        public TranslationController(TranslationService translationService, ILogger<TextAnalyticsController> logger)
        {
            _logger = logger;
            _translationService = translationService;
        }


        [HttpPost("translate")]
        public async Task<ApiResult> DetectLanguageBatch([FromBody] TranslationRequest request)
        {
            var result = await _translationService.TranslateAsync(request.To,
                                        request.Text,
                                        request.From,
                                        request.toScript);
            return ApiResult.OK(result);
        }

        [HttpGet("languages")]
        public async Task<ApiResult> GetSupportedLanguages([FromQuery] string? scope = null)
        {
            var result = await _translationService.GetSupportedLanguages(scope);
            return ApiResult.OK(result);
        }

    }
}
