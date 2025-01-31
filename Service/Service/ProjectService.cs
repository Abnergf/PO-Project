using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Model;
namespace Core.Service
{
    public class ProjectService : IProjectService
    {
        public readonly IProjectRepository _projectRepository;
        public readonly IProjectTasksService _projectTasksService;
        public ProjectService(IProjectRepository projectRepository, IProjectTasksService projectTasksService)
        {
            _projectRepository = projectRepository;
            _projectTasksService = projectTasksService;
        }
        public Task<IEnumerable<ProjectResponse>> CheckProjects()
        {
            return _projectRepository.CheckProjects();
        }
        public async Task CreateProject(CreateProjectRequest projectRequest)
        {
            Project project = new Project(projectRequest);
            await _projectRepository.CreateProject(project);
        }
        public async Task AlterProject(AlterProjectRequest alterProject)
        {
            var project = await _projectRepository.GetProjectByIdAsync(alterProject.Id);
            if (project == null)
                throw new ArgumentException("Id Not Found");
            project.Update(alterProject);
            await _projectRepository.AlterProject(project);
        }
        public async Task DeleteProject(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
                throw new ArgumentException("Id Not Found");
            await _projectTasksService.DeleteTaskFiles(project.TaskFiles);
            await _projectTasksService.DeleteListOfProjectTasks(project.ProjectTasks);
            await _projectRepository.DeleteProject(id);
        }
        public Task<IEnumerable<ProjectTaskFilesResponse>> CheckFilesTask()
        {
            return _projectRepository.CheckFilesTask();
        }
        public async Task CreateTaskFiles(CreateTaskFilesRequest createTaskFilesRequest)
        {
            TaskFiles taskFiles = new TaskFiles(createTaskFilesRequest);
            await _projectRepository.CreateTaskFiles(taskFiles);
        }
        public async Task AlterTaskFiles(AlterTaskFilesRequest alterTaskFiles)
        {
            var taskFiles = await _projectRepository.GetTaskFilesByIdAsync(alterTaskFiles.Id);
            if (taskFiles == null)
                throw new ArgumentException("Id Not Found");
            taskFiles.Update(alterTaskFiles);
            await _projectRepository.AlterTaskFiles(taskFiles);
        }
    }
}