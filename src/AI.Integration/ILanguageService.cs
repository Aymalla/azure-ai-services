using Azure.AI.TextAnalytics;

namespace AI.Integration
{
    public interface ILanguageService
    {

        Task<DetectLanguageResultCollection> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents);

        Task<AnalyzeSentimentResultCollection> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents);

        Task<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents);

        Task<RecognizeEntitiesResultCollection> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents);

        Task<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents);

        Task<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents);
    }
}

