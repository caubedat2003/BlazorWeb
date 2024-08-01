using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Repositories;
using TodoList.Models;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUserList();
            var assignees = users.Select(x => new AssigneeDto()
            {
               Id = x.Id,
               FullName = x.FirstName + " " + x.LastName,
               UserRole = x.UserRole,
            });
            //return Ok(assignees);
            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);

                if (user == null)
                {
                    return NotFound(); // User with the given ID not found
                }

                //var assignee = new AssigneeDto()
                //{
                //    Id = user.Id,
                //    FullName = user.FirstName + " " + user.LastName,
                //    UserRole = user.UserRole,
                //};

                //return Ok(assignee);

                return Ok(new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    UserRole = user.UserRole
                });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request."); // Internal server error
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  UserCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.Create(new Entities.User()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserRole = Models.Enums.UserRole.Receptionist,
            });
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userFromDb = await _userRepository.GetUserById(id);
            if(userFromDb == null) return NotFound("Không tìm thấy người dùng");

            userFromDb.FirstName = request.FirstName;
            userFromDb.LastName = request.LastName;
            userFromDb.Email = request.Email;
            userFromDb.UserRole = request.UserRole;

            var result = await _userRepository.Update(userFromDb);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) return NotFound("Không tìm thấy người dùng");
            await _userRepository.Delete(user);
            return Ok(new AssigneeDto()
            {
                Id = id,
                FullName = user.FirstName + " " + user.LastName,
                UserRole = user.UserRole,
            });
        }
        [HttpPut]
        [Route("{id}/role")]
        public async Task<IActionResult> EditRole(Guid id, [FromBody] EditRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userFromDb = await _userRepository.GetUserById(id);
            if (userFromDb == null) return NotFound("Không tìm thấy người dùng");

            userFromDb.UserRole = request.UserRole;
            var userResult = await _userRepository.Update(userFromDb);
            return Ok(new EditRoleRequest()
            {
                Id = userResult.Id,
                UserRole = userResult.UserRole,
            });
        }
    }
}
