using System.Net;

namespace AI.Integration.APIs.Models
{
    public class SpeechTranslationRequest
    {
        public string? From { get; set; } // null to auto-detect
        public string? To { get; set; } = "ar";
    }
}