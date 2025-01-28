using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Model;
namespace Core.Service
{
    public class ProjectTasksService : IProjectTasksService
    {
        private readonly IProjectTasksRepository _projectTasksRepository;
        public ProjectTasksService(IProjectTasksRepository projectTasksRepository)
        {
            _projectTasksRepository = projectTasksRepository;
        }
        public Task<IEnumerable<ProjectTasksResponse>> CheckProjectTasks()
        {
            return _projectTasksRepository.CheckProjectTasks();
        }
        public async Task CreateProjectTasks(CreateProjectTaskRequest createProjectTask)
        {
            ProjectTasks projectTasks = new ProjectTasks(createProjectTask);
            await _projectTasksRepository.CreateProjectTasks(projectTasks);
        }
        public async Task AlterProjectTasks(AlterProjectTaskRequest alterProjectTask)
        {
            var projectTasks = await _projectTasksRepository.GetByIdAsync(alterProjectTask.Id);
            if (projectTasks == null)
                throw new ArgumentException("Id não encontrado");
            projectTasks.Update(alterProjectTask);
            await _projectTasksRepository.AlterProjectTasks(projectTasks);
        }
        public async Task DeleteProjectTasks(int id)
        {
            var projectTasks = await _projectTasksRepository.GetByIdAsync(id);
            if (projectTasks == null)
                throw new ArgumentException("Id não encontrado");
            await _projectTasksRepository.DeleteProjectTasks(id);
        }
    }
}