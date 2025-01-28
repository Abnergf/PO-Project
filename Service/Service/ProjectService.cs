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
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
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
            var project = await _projectRepository.GetByIdAsync(alterProject.Id);
            if (project == null)
                throw new ArgumentException("Id Not Found");
            project.Update(alterProject);
            await _projectRepository.AlterProject(project);
        }
        public async Task DeleteProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                throw new ArgumentException("Id Not Found");
            await _projectRepository.DeleteProject(id);
        }
    }
}