using TestTechniqueC_.Models;

namespace TestTechniqueC_.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
        bool Insert(Project entity);
    }
}
