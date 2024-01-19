using Azure;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Translation;
using Azure.AI.Vision.Common;
using Azure.AI.Vision.ImageAnalysis;

namespace AI.Integration
{
    /// <summary>
    /// This is a wrapper around the Azure Cognitive Services Computer Vision client.
    /// Samples: https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/quickstarts-sdk/image-analysis-client-library-40
    /// </summary>
    public class ComputerVisionService
    {
        //private readonly TextTranslationClient _textTranslationClient;
        private readonly VisionServiceOptions _visionServiceOptions;

        public ComputerVisionService(Settings settings)
        {
            _visionServiceOptions = new VisionServiceOptions(settings.AZURE_AI_SERVICE_ENDPOINT,
                new AzureKeyCredential(settings.AZURE_AI_SERVICE_KEY));
        }

        public async Task<ImageAnalysisResult> AnalyzeAsync(string imageUrl)
        {
            using var imageSource = VisionSource.FromUrl(new Uri(imageUrl));
            var analysisOptions = new ImageAnalysisOptions()
            {
                Features = ImageAnalysisFeature.Caption | ImageAnalysisFeature.Text,
                Language = "en",
                GenderNeutralCaption = true
            };

            using var analyzer = new ImageAnalyzer(_visionServiceOptions, imageSource, analysisOptions);
            var result = await analyzer.AnalyzeAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<ImageAnalysisResult> AnalyzeAsync(string imageUrl)
        {
            using var imageSource = VisionSource.FromUrl(new Uri(imageUrl));
            var analysisOptions = new ImageAnalysisOptions()
            {
                Features = ImageAnalysisFeature.Caption | ImageAnalysisFeature.Text,
                Language = "en",
                GenderNeutralCaption = true
            };

            using var analyzer = new ImageAnalyzer(_visionServiceOptions, imageSource, analysisOptions);
            var result = await analyzer.C().ConfigureAwait(false);
            return result;
        }
    }
}
