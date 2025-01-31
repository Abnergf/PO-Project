using Domain.Interface.RepositoryInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.MainDbContext;
namespace Infra.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly MainDbContext _context;
        public ProjectRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProjectResponse>> CheckProjects()
        {
            var project = await _context.Project
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    CreationDate = p.CreationDate,
                    Status = p.Status,
                })
                .ToListAsync();
            return project;
        }
        public async Task CreateProject(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task AlterProject(Project project)
        {
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
        }
        public async Task<Project?> GetProjectByIdAsync (int id)
        {
            return await _context.Project.FindAsync(id);
        }
        public async Task DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            
            var projectTasks = await _context.ProjectTasks
                               .Where(p => p.ProjectId == project.Id)
                               .ToListAsync();

            foreach (var projectTask in projectTasks)
            {
                var taskFiles = await _context.TaskFiles
                                .Where(f => f.ProjectTaskId == projectTask.Id)
                                .ToListAsync();

                _context.TaskFiles.RemoveRange(taskFiles);
                _context.ProjectTasks.Remove(projectTask);
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProjectTaskFilesResponse>> CheckFilesTask()
        {
            var taskFiles = await _context.TaskFiles
                .Select(p => new ProjectTaskFilesResponse
                {
                    Id = p.Id,
                    ProjectTaskId = p.ProjectTaskId,
                    FileTitle = p.FileTitle,
                    FileURL = p.FileURL,
                })
                .ToListAsync();
            return taskFiles;
        }
        public async Task CreateTaskFiles(TaskFiles taskFiles)
        {
            _context.TaskFiles.Add(taskFiles);
            await _context.SaveChangesAsync();
        }
        public async Task AlterTaskFiles(TaskFiles taskFiles)
        {
            _context.TaskFiles.Update(taskFiles);
            await _context.SaveChangesAsync();
        }
        public async Task<TaskFiles?> GetTaskFilesByIdAsync(int id)
        {
            return await _context.TaskFiles.FindAsync(id);
        }
    }
}