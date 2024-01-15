using System.Net;

namespace AI.Integration.APIs.Models
{
    public class TranslationRequest
    {
        public string? Text { get; set; }
        public string? From { get; set; } // null to auto-detect
        public string? To { get; set; } = "ar";
        public string toScript { get; set; } = "Latn";
    }
}