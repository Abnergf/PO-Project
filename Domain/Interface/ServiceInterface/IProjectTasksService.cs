using Domain.Request;
using Domain.Response;
namespace Domain.Interface.ServiceInterface
{
    public interface IProjectTasksService
    {
        Task<IEnumerable<ProjectTasksResponse>> CheckProjectTasks();
        Task CreateProjectTasks(CreateProjectTaskRequest createProjectTask);
        Task AlterProjectTasks(AlterProjectTaskRequest alterProjectTask);
        Task DeleteProjectTasks(int id);
    }
}