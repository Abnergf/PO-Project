using Microsoft.AspNetCore.Mvc;
using Domain.Interface.ServiceInterface;
using Domain.Response;
namespace Projeto_Principal.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _mainService;
        public ReportController(IReportService mainService)
        {
            _mainService = mainService;
        }
        [HttpGet("check-project-report")]
        public async Task<ActionResult<IEnumerable<ReportProjectResponse>>> ProjectReport()
        {
            return Ok(new
            {
                sucess = true,
                data = await _mainService.ProjectReport()
            });
        }
        [HttpGet("check-professional-report")]
        public async Task<ActionResult<IEnumerable<ReportProfessionalResponse>>> ProfessionalReport()
        {
            return Ok(new
            {
                sucess = true,
                data = await _mainService.ProfessionalReport()
            });
        }
        [HttpGet("check-project-time")]
        public async Task<ActionResult<IEnumerable<ReportProjectTimeResponse>>> ProjectTime(int HourParameter)
        {
            return Ok(new
            {
                sucess = true,
                data = await _mainService.ProjectTime(HourParameter)
            });
        }
    }
}