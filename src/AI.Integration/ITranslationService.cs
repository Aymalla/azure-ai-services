
using Azure.AI.Translation.Text;

namespace AI.Integration
{
    public interface ITranslationService
    {
        Task<IReadOnlyList<TranslatedTextItem>> TranslateAsync(string? targetLanguage, string? text, string? sourceLanguage = null, string? fromScript = null, string toScript = "Latn");

        Task<GetLanguagesResult> GetSupportedLanguages(string? scope = null);
    }
}

