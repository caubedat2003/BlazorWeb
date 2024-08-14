using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Repositories;
using TodoList.Models;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentsController : ControllerBase
    {
        private readonly IRoleAssignmentRepository _roleAssignmentRepository;
        public RoleAssignmentsController(IRoleAssignmentRepository roleAssignmentRepository)
        {
            _roleAssignmentRepository = roleAssignmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleAssignments()
        {
            var assignments = await _roleAssignmentRepository.GetRoleAssignments();
            return Ok(assignments);
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveRoleAssignments([FromBody] List<PageRoleAssignment> assignments)
        {
            await _roleAssignmentRepository.SaveRoleAssignments(assignments);
            return Ok();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateRoleAssignment([FromBody] PageRoleAssignment assignment)
        {
            if(assignment == null)
            {
                return BadRequest();
            }
            await _roleAssignmentRepository.CreateAssignment(assignment);
            return CreatedAtAction(nameof(GetRoleAssignments), new {id  = assignment.Id}, assignment);
        }
    }
}
