using Domain.Request;
using Domain.Response;
namespace Domain.Interface.ServiceInterface
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectResponse>> CheckProjects();
        Task AlterProject(AlterProjectRequest alterProject);
        Task CreateProject(CreateProjectRequest projectRequest);
        Task DeleteProject(int id);
    }
}