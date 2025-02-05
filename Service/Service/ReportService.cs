using Domain.Enum;
using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Response;
namespace Core.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _mainRepository;
        public ReportService(IReportRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }
        public async Task<IEnumerable<ReportProjectResponse>> ProjectReport() 
        {
            return await _mainRepository.ProjectReport();
        }
        public async Task<List<ReportProfessionalResponse>> ProfessionalReport()
        {
            var reportProfessionals = await _mainRepository.ProfessionalReport();
            return reportProfessionals
            .Select(g => new ReportProfessionalResponse
            {
                Id = g.Id,
                Name = g.Name,
                TotalFinishedTasks = g.ProjectTasks.Count(t => t.Status == Status.Completed),
                TotalUnfinishedTasks = g.ProjectTasks.Count(t => t.Status != Status.Completed),
                TotalHoursFinishedTasks = g.ProjectTasks
                .Where(t => t.Status == Status.Completed)
                .Select(t => new {t.StartDate, t.CompletedDate}).AsEnumerable()
                .Sum(t => (int)(t.CompletedDate - t.StartDate).TotalHours),
                TotalHoursUnfinishedTasks = g.ProjectTasks
                .Where(t => t.Status != Status.Completed)
                .Select(t => new { t.StartDate }).AsEnumerable() // teste
                .Sum(t => (int)(DateTime.UtcNow - t.StartDate).TotalHours)
            })
            .ToList();
        }
        public async Task<IEnumerable<ReportProjectTimeResponse>> ProjectTime(int HourParameter)
        {
            return await _mainRepository.ProjectTime(HourParameter);
        }
    }
}