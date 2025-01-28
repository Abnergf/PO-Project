using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
namespace Projeto_Principal.Controller
{
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTasksService _projectTasksService;
        public ProjectTasksController(IProjectTasksService projectTasksService)
        {
            _projectTasksService = projectTasksService;
        }
        [HttpGet("check-projectsTasks")]
        public async Task<ActionResult<IEnumerable<ProjectTasksResponse>>> CheckProjectTasks()
        {
            return Ok(new
            {
                sucess = true,
                data = await _projectTasksService.CheckProjectTasks()
            });
        }
        [HttpPost("create-projectsTasks")]
        public async Task<ActionResult<CreateProjectTaskRequest>> CreateProjectTasks(CreateProjectTaskRequest createProjectTask)
        {
            await _projectTasksService.CreateProjectTasks(createProjectTask);
            return Ok();
        }
        [HttpPut("alter-projectsTasks")]
        public async Task<ActionResult<List<AlterProjectTaskRequest>>> AlterProjectTasks(AlterProjectTaskRequest alterProjectTask)
        {
            await _projectTasksService.AlterProjectTasks(alterProjectTask);
            return Ok();
        }
        [HttpDelete("delete-projectsTasks/{id}")]
        public async Task<ActionResult> DeleteProjectTasks(int id)
        {
            await _projectTasksService.DeleteProjectTasks(id);
            return Ok();
        }
    }
}