using System.Net;
using System.Text.Json.Serialization;
using TestTechniqueC_.DTOs;

namespace TestTechniqueC_.Models
{
    public class ProjectsRepresentation
    {
        public ProjectsRepresentation(List<ProjectDTO> projects, HttpStatusCode statusCode)
        {
            Projects = projects;
            StatusCode = statusCode;
        }

        [JsonPropertyName("projects")]
        public List<ProjectDTO> Projects { get; set; } = new();

        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; set; }
    }
}
