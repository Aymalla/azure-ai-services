using AI.Integration.APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Azure.AI.TextAnalytics;

namespace AI.Integration.APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextAnalyticsController : ControllerBase
    {
        private readonly ILogger<TextAnalyticsController> _logger;
        private readonly ILanguageService _textAnalyticsService;

        public TextAnalyticsController(ILanguageService languageService, ILogger<TextAnalyticsController> logger)
        {
            _logger = logger;
            _textAnalyticsService = languageService;
        }


        [HttpPost("detectLanguage")]
        public async Task<ApiResult> DetectLanguageBatch([FromBody] IEnumerable<DetectLanguageInput> documents)
        {
            var result = await _textAnalyticsService.DetectLanguageBatchAsync(documents);
            return ApiResult.OK(result);
        }

        [HttpPost("analyzeSentiment")]
        public async Task<ApiResult> AnalyzeSentimentBatch([FromBody] IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsService.AnalyzeSentimentBatchAsync(documents);
            return ApiResult.OK(result);
        }

        [HttpPost("extractKeyPhrases")]
        public async Task<ApiResult> ExtractKeyPhrasesBatch([FromBody] IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsService.ExtractKeyPhrasesBatchAsync(documents);
            return ApiResult.OK(result);
        }

        [HttpPost("recognizeEntities")]
        public async Task<ApiResult> RecognizeEntitiesBatch([FromBody] IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsService.RecognizeEntitiesBatchAsync(documents);
            return ApiResult.OK(result);
        }

        [HttpPost("recognizeLinkedEntities")]
        public async Task<ApiResult> RecognizeLinkedEntitiesBatch([FromBody] IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsService.RecognizeLinkedEntitiesBatchAsync(documents);
            return ApiResult.OK(result);
        }

        [HttpPost("recognizePiiEntities")]
        public async Task<ApiResult> RecognizePiiEntitiesBatch([FromBody] IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsService.RecognizePiiEntitiesBatchAsync(documents);
            return ApiResult.OK(result);
        }


    }
}
