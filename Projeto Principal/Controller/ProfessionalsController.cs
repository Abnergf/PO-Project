using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
namespace Projeto_Principal.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessionalsController : ControllerBase
    {
        private readonly IProfessionalService _professionalService;
        public ProfessionalsController(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }
        [HttpGet("check-professional")]
        public async Task<ActionResult<IEnumerable<ProfessionalResponse>>> CheckProfessionals()
        {
            return Ok(new
            {
                sucess = true,
                data = await _professionalService.CheckProfessionals()
            });
        }
        [HttpPost("create-professional")]
        public async Task<ActionResult<CreateProfessionalsRequest>> CreateProfessionals(CreateProfessionalsRequest createProfessionals)
        {
            await _professionalService.CreateProfessionals(createProfessionals);
            return Ok();
        }
        [HttpPut("alter-professional")]
        public async Task<ActionResult<List<AlterProfessionalsRequest>>> AlterProfessional(AlterProfessionalsRequest alterProfessional)
        {
            await _professionalService.AlterProfessionals(alterProfessional);
            return Ok();
        }
        [HttpDelete("delete-professional/{id}")]
        public async Task<ActionResult> DeleteProfessionals(int id)
        {
            await _professionalService.DeleteProfessionals(id);
            return Ok();
        }
    }
}