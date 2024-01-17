using Azure;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Translation;

namespace AI.Integration
{
    /// <summary>
    /// This is a wrapper around the Azure Cognitive Services Text Translation client.
    /// Samples: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples
    /// </summary>
    public class SpeechService
    {
        //private readonly TextTranslationClient _textTranslationClient;
        private readonly SpeechTranslationConfig _speechTranslationConfig;

        public SpeechService(SpeechTranslationConfig speechTranslationConfig)
        {
            _speechTranslationConfig = speechTranslationConfig;
            // _textTranslationClient = textTranslationClient;
        }

        public async Task<TranslationRecognitionResult> TranslateAsync(string wavFilePath)
        {
            // When you use Language ID with speech translation, you must set a v2 endpoint and use
            // SpeechTranslationConfig.FromEndpoint() to create the SpeechTranslationConfig object.
            // This will be fixed in a future version of Speech SDK.

            // Translation target language(s).
            // Replace with language(s) of your choice.
            _speechTranslationConfig.AddTargetLanguage("de");
            _speechTranslationConfig.AddTargetLanguage("fr");
            _speechTranslationConfig.AddTargetLanguage("ar");
            _speechTranslationConfig.SpeechRecognitionLanguage = "en-US";

            // https://learn.microsoft.com/en-us/azure/ai-services/speech-service/how-to-configure-openssl-linux?pivots=programming-language-csharp
            //_speechTranslationConfig.SetProperty("OPENSSL_CONTINUE_ON_CRL_DOWNLOAD_FAILURE", "true");
            _speechTranslationConfig.SetProperty("OPENSSL_DISABLE_CRL_CHECK", "true");

            // Set the mode of input language detection to either "AtStart" (the default) or "Continuous".
            // Please refer to the documentation of Language ID for more information.
            // https://aka.ms/speech/lid?pivots=programming-language-csharp
            //_speechTranslationConfig.SetProperty(PropertyId.SpeechServiceConnection_LanguageIdMode, "Continuous");

            // Define the set of languages to detect
            var autoDetectSourceLanguageConfig = AutoDetectSourceLanguageConfig.FromLanguages(new string[] { "en-US", "zh-CN" });
            
            // Creates a translation recognizer using file as audio input.
            // Replace with your own audio file name.
            using var audioInput = AudioConfig.FromWavFileInput(wavFilePath);
            using var recognizer = new TranslationRecognizer(_speechTranslationConfig, audioInput);
            return await recognizer.RecognizeOnceAsync().ConfigureAwait(false);
        }
    }
}
