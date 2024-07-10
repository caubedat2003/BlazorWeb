using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Entities;
using TodoList.Models;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RegisterResponse
                {
                    Successful = false,
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage))
                });
            }

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserRole = Models.Enums.UserRole.Receptionist
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
            {
                return BadRequest(new RegisterResponse
                {
                    Successful = false,
                    Errors = result.Errors.Select(e => e.Description)
                });
            }
            return Ok(new RegisterResponse { Successful = true});
        }
    }
}
