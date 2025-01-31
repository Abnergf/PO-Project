using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.IdentityModel.Tokens;
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
        public async Task DeleteListOfProjectTasks(ICollection<ProjectTasks> projectTasks)
        {
            foreach (var task in projectTasks)
            {
                
            }
            if (!projectTasks.IsNullOrEmpty())
            {
                await _projectTasksRepository.DeleteListOfProjectTasks(projectTasks.Select(p => p.Id));
            }
            return;
        }
        public async Task DeleteTaskFiles(ICollection<TaskFiles> taskFiles)
        {
            if (taskFiles != null && taskFiles.Count > 0)
            {
                await _projectTasksRepository.DeleteTaskFiles(taskFiles.Select(p => p.Id));
            }
        }
    }
}