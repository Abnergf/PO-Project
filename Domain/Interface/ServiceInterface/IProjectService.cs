using Domain.Request;
using Domain.Response;
using Model;
namespace Domain.Interface.ServiceInterface
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectResponse>> CheckProjects();
        Task AlterProject(AlterProjectRequest alterProject);
        Task CreateProject(CreateProjectRequest projectRequest);
        Task DeleteProject(int id);
        public Task<IEnumerable<ProjectTaskFilesResponse>> CheckFilesTask();
        Task CreateTaskFiles(CreateTaskFilesRequest createTaskFilesRequest);
        Task AlterTaskFiles(AlterTaskFilesRequest alterTaskFilesRequest);
        Task DeleteTaskFiles(int id);
    }
}