using Azure;
using Azure.AI.TextAnalytics;

namespace AI.Integration
{
    /// <summary>
    /// This is a wrapper around the Azure Cognitive Services Text Analytics client.
    /// Samples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/README.md
    /// </summary>
    public class LanguageService : ILanguageService
    {
        private readonly TextAnalyticsClient _textAnalyticsClient;

        public LanguageService(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        public async Task<DetectLanguageResultCollection> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents)
        {
            var result = await _textAnalyticsClient.DetectLanguageBatchAsync(documents);
            return result.Value;
        }

        public async Task<AnalyzeSentimentResultCollection> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsClient.AnalyzeSentimentBatchAsync(documents);
            return result.Value;
        }

        public async Task<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsClient.ExtractKeyPhrasesBatchAsync(documents);
            return result.Value;
        }

        public async Task<RecognizeEntitiesResultCollection> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsClient.RecognizeEntitiesBatchAsync(documents);
            return result.Value;
        }

        public async Task<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsClient.RecognizeLinkedEntitiesBatchAsync(documents);
            return result.Value;
        }

        public async Task<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents)
        {
            var result = await _textAnalyticsClient.RecognizePiiEntitiesBatchAsync(documents);
            return result.Value;
        }

    }
}
