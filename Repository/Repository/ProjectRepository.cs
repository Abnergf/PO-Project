using Domain.Interface.RepositoryInterface;
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
        public async Task<Project?> GetByIdAsync (int id)
        {
            return await _context.Project.FindAsync(id);
        }
        public async Task DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}