using Domain.Interface.RepositoryInterface;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.MainDbContext;
namespace Infra.Repository
{
    public class ProjectTasksRepository : IProjectTasksRepository
    {
        private readonly MainDbContext _context;
        public ProjectTasksRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProjectTasksResponse>> CheckProjectTasks()
        {
            var projectTasks = await _context.ProjectTasks
                .Select(p => new ProjectTasksResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    EstimatedTime = p.EstimatedTime,
                    CreationDate = p.CreationDate,
                    StartDate = p.StartDate,
                    CompletedDate = p.CompletedDate,
                    ProfessionalId = p.ProfessionalId,
                    ProjectId = p.ProjectId,
                    Status = p.Status,
                })
                .ToListAsync();
            return projectTasks;
        }
        public async Task CreateProjectTasks(ProjectTasks projectTasks)
        {
            _context.ProjectTasks.Add(projectTasks);
            await _context.SaveChangesAsync();
        }
        public async Task AlterProjectTasks(ProjectTasks projectTasks)
        {
            _context.ProjectTasks.Update(projectTasks);
            await _context.SaveChangesAsync();
        }
        public async Task<ProjectTasks?> GetByIdAsync(int id)
        {
            return await _context.ProjectTasks.FindAsync(id);
        }
        public async Task DeleteProjectTasks(int id)
        {
            var projectTasks = await _context.ProjectTasks.FindAsync(id);
            _context.ProjectTasks.Remove(projectTasks);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteListOfProjectTasks(IEnumerable<int> projectTasksIds)
        {
            var projectTasks = await _context.ProjectTasks.Where(p => projectTasksIds.Contains(p.Id)).ToListAsync();
            _context.ProjectTasks.RemoveRange(projectTasks);
        }

        public async Task DeleteTaskFiles(IEnumerable<int> tasksIds)
        {
            var taskFiles = await _context.TaskFiles
                            .Where(p => tasksIds
                            .Contains(p.Id))
                            .ToListAsync();
            _context.TaskFiles.RemoveRange(taskFiles);
        }
    }
}