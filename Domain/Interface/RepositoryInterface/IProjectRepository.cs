using Domain.Response;
using Model;
namespace Domain.Interface.RepositoryInterface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectResponse>> CheckProjects();
        Task CreateProject(Project project);
        Task AlterProject(Project project);
        Task DeleteProject(int id);
        Task<Project?> GetByIdAsync(int id);
    }
}