using Domain.Enum;
using Domain.Interface.RepositoryInterface;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.MainDbContext;
namespace Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly MainDbContext _context;
        public ReportRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReportProjectResponse>> ProjectReport()
        {
            var main = await _context.Project
                .AsNoTracking()
                .Include(p => p.ProjectTasks)
                .Include(p => p.ProfessionalsInProjects)
                .Select(p => new ReportProjectResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    TotalTasks = p.ProjectTasks.Count(),
                    TotalFinishedTasks = p.ProjectTasks.Count(t => t.Status == Status.Completed),
                    TotalUnfinishedTasks = p.ProjectTasks.Count(t => t.Status != Status.Completed)
                })
                .ToListAsync();
            return main;
        }
        public async Task<List<Professionals>> ProfessionalReport()
        {
            var reportProfessionals = await _context.Professionals
                .Include(p => p.ProjectTasks)
                .Include(p => p.FieldOfOperation)
                .ToListAsync();
            return reportProfessionals;
        }
        public async Task<IEnumerable<ReportProjectTimeResponse>> ProjectTime(int HourParameter)
        {
            var projectTime = await _context.Project
                .Select(p => new ReportProjectTimeResponse
                {
                    Id = p.Id,
                    Name = p.Title,
                    ProjectTime = EF.Functions.DateDiffHour(p.CreationDate, DateTime.UtcNow)
                })
                .Where(p => p.ProjectTime >= HourParameter)
                .ToListAsync();
            return projectTime;
        }
    }
}