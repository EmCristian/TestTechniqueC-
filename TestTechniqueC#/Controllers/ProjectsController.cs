using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTechniqueC_.DTOs;
using TestTechniqueC_.Models;
using TestTechniqueC_.Repositories;

namespace TestTechniqueC_.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectsController : ControllerBase
    {
        private Mapper _mapper { get; set; }
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _mapper = MapperConfig.Initialize();
        }

        [HttpGet(Name = "Get Projects")]
        public ProjectsRepresentation GetProjects()
        {
            var projects = _projectRepository.GetAllProjects();

            List<ProjectDTO> result = projects.Select(x => _mapper.Map<ProjectDTO>(x)).ToList();

            return new ProjectsRepresentation(result, HttpStatusCode.OK);
        }

        [HttpPost(Name = "Insert Project")]
        public ProjectRepresentation InsertProject([FromBody] ProjectModel project)
        {
            if (!ModelState.IsValid)
                return new ProjectRepresentation("Wrong payload", HttpStatusCode.BadRequest);

            Project entity = project.GetEntity();
            bool saved = _projectRepository.Insert(entity);

            if (saved)
                return new ProjectRepresentation("Project has been saved!", HttpStatusCode.OK);
            else
                return new ProjectRepresentation("Something went wrong!", HttpStatusCode.InternalServerError);

        }
    }
}