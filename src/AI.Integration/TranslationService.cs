using Azure;
using Azure.AI.Translation.Text;

namespace AI.Integration
{
    /// <summary>
    /// This is a wrapper around the Azure Cognitive Services Text Translation client.
    /// Samples: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples
    /// </summary>
    public class TranslationService
    {
        private readonly TextTranslationClient _textTranslationClient;

        public TranslationService(Settings settings)
        {
            _textTranslationClient = new TextTranslationClient(
                new AzureKeyCredential(settings.AZURE_AI_SERVICE_KEY),
                new Uri(settings.AZURE_AI_SERVICE_ENDPOINT));
        }

        public async Task<IReadOnlyList<TranslatedTextItem>> TranslateAsync(string? targetLanguage, string? text, string? sourceLanguage = null, string? fromScript= null, string toScript = "Latn")
        {
            var result = await _textTranslationClient.TranslateAsync([targetLanguage],
                [text],
                sourceLanguage: sourceLanguage,
                includeAlignment: true,
                includeSentenceLength: true,
                fromScript: fromScript, 
                toScript: toScript);
            return result.Value;
        }

        public async Task<GetLanguagesResult> GetSupportedLanguages(string? scope = null)
        {
            var result = await _textTranslationClient.GetLanguagesAsync(scope);
            return result.Value;
        }
    }
}
