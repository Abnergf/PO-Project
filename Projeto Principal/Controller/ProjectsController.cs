﻿using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
namespace Projeto_Principal.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private object createTaskFilesRequest;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet("check-projects")]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> CheckProjects()
        {
            return Ok(new
            {
                sucess = true,
                data = await _projectService.CheckProjects()
            });
        }
        [HttpPost("create-project")]
        public async Task<ActionResult<CreateProjectRequest>> CreateProject(CreateProjectRequest projectRequest)
        {
            await _projectService.CreateProject(projectRequest);
            return Ok();
        }
        [HttpPut("alter-project")]
        public async Task<ActionResult<List<AlterProjectRequest>>> AlterProject(AlterProjectRequest alterProject)
        {
            await _projectService.AlterProject(alterProject);
            return Ok();
        }
        [HttpDelete("delete-project/{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
            return Ok();
        }
        [HttpGet("check-taskfiles")]
        public async Task<ActionResult<IEnumerable<ProjectTaskFilesResponse>>> CheckFilesTask()
        {
            return Ok(new
            {
                sucess = true,
                data = await _projectService.CheckFilesTask()
            });
        }
        [HttpPost("create-taskfiles")]
        public async Task<ActionResult> CreateTaskFiles(CreateTaskFilesRequest createTaskFilesRequest)
        {
            await _projectService.CreateTaskFiles(createTaskFilesRequest);
            return Ok();
        }
        [HttpPut("alter-taskfiles")]
        public async Task<ActionResult> AlterTaskFiles(AlterTaskFilesRequest alterTaskFilesRequest)
        {
            await _projectService.AlterTaskFiles(alterTaskFilesRequest);
            return Ok();
        }
        [HttpDelete("delete-taskfiles/{id}")]
        public async Task<ActionResult> DeleteTaskFiles(int id)
        {
            await _projectService.DeleteTaskFiles(id);
            return Ok();
        }
    }
}