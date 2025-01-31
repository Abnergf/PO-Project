using Domain.Response;
using Model;
namespace Domain.Interface.RepositoryInterface
{
    public interface IProjectTasksRepository
    {
        Task<IEnumerable<ProjectTasksResponse>> CheckProjectTasks();
        Task CreateProjectTasks(ProjectTasks projectTasks);
        Task AlterProjectTasks(ProjectTasks projectTasks);
        Task<ProjectTasks?> GetByIdAsync(int id);
        Task DeleteProjectTasks(int id);
        Task DeleteListOfProjectTasks(IEnumerable<int> projectTasksIds);
        Task DeleteTaskFiles(IEnumerable<int> tasksIds); //rever o repo;
    }
}