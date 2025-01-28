using Domain.Response;
using Model;
namespace Domain.Interface.RepositoryInterface
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportProjectResponse>> ProjectReport();
        Task<List<Professionals>> ProfessionalReport();
        Task<IEnumerable<ReportProjectTimeResponse>> ProjectTime(int HourParameter);

    }
}