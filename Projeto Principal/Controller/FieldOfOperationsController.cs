using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
namespace Projeto_Principal.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class FieldOfOperationsController : ControllerBase
    {
        private readonly IFieldOfOperationService _fieldOfOperationService;
        public FieldOfOperationsController(IFieldOfOperationService fieldOfOperation)
        {
            _fieldOfOperationService = fieldOfOperation;
        }
        [HttpGet("check-fieldOfOperation")]
        public async Task<ActionResult<IEnumerable<FieldOfOperationsResponse>>> CheckFieldOfOperation()
        {
            return Ok(new
            {
                sucess = true,
                data = await _fieldOfOperationService.CheckFieldOfOperation()
            });
        }
        [HttpPost("create-fieldOfOperation")]
        public async Task<ActionResult<CreateFieldOfOperationRequest>> CreateFieldOfOperation(CreateFieldOfOperationRequest createFieldOfOperation)
        {
            await _fieldOfOperationService.CreateFieldOfOperation(createFieldOfOperation);
            return Ok();
        }
        [HttpPut("alter-fieldOfOperation")]
        public async Task<ActionResult<List<CreateFieldOfOperationRequest>>> AlterFieldOfOperation(AlterFieldOfOperationRequest alterFieldOfOperation)
        {
            await _fieldOfOperationService.AlterFieldOfOperation(alterFieldOfOperation);
            return Ok();
        }
        [HttpDelete("delete-fieldOfOperation/{id}")]
        public async Task<ActionResult> DeleteFieldOfOperation(int id)
        {
            await _fieldOfOperationService.DeleteFieldOfOperation(id);
            return Ok();
        }
    }
}