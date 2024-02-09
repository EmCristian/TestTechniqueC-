using System.Net;
using System.Text.Json.Serialization;

namespace TestTechniqueC_.Models
{
    public class ProjectRepresentation
    {
        public ProjectRepresentation(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; set; }
    }
}
