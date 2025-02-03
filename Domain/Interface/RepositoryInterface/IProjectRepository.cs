using Domain.Request;
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
        Task<Project?> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectTaskFilesResponse>> CheckFilesTask();
        Task CreateTaskFiles(TaskFiles taskFiles);
        Task AlterTaskFiles(TaskFiles taskFiles);
        Task<TaskFiles?> GetTaskFilesByIdAsync(int id);
        Task DeleteTaskFiles(int id);
    }
}