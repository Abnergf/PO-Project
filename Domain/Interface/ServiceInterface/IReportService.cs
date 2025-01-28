using Domain.Response;
namespace Domain.Interface.ServiceInterface
{
    public interface IReportService
    {
        Task<IEnumerable<ReportProjectResponse>> ProjectReport();
        Task<List<ReportProfessionalResponse>> ProfessionalReport();
        Task<IEnumerable<ReportProjectTimeResponse>> ProjectTime(int HourParameter);
    }
}