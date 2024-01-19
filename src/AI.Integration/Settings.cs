using System.Net;

namespace AI.Integration
{
    public class Settings
    {
        public Settings(string azureAiServiceEndpoint, string azureAiServiceKey, string azureAiServiceRegion, string azureLangServiceEndpoint, string azureLangServiceKey, string azureLangServiceRegion)
        {
            AZURE_AI_SERVICE_ENDPOINT = azureAiServiceEndpoint;
            AZURE_AI_SERVICE_KEY = azureAiServiceKey;
            AZURE_AI_SERVICE_REGION = azureAiServiceRegion;
            AZURE_LANG_SERVICE_ENDPOINT = azureLangServiceEndpoint;
            AZURE_LANG_SERVICE_KEY = azureLangServiceKey;
            AZURE_LANG_SERVICE_REGION = azureLangServiceRegion;
        }
        
        public string AZURE_AI_SERVICE_ENDPOINT { get; set; }
        public string AZURE_AI_SERVICE_KEY { get; set; }
        public string AZURE_AI_SERVICE_REGION { get; set; }

        public string AZURE_LANG_SERVICE_ENDPOINT { get; set; }
        public string AZURE_LANG_SERVICE_KEY { get; set; }
        public string AZURE_LANG_SERVICE_REGION { get; set; }

    }
}