using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Repositories;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly PageAuthorizationService _pageAuthorizationService;
        public AuthorizationController(PageAuthorizationService pageAuthorizationService)
        {
            _pageAuthorizationService = pageAuthorizationService;
        }
        [HttpGet]
        [Route("IsUserAuthorizedForPage/{pageName}")]
        public async Task<IActionResult> IsUserAuthorizedForPage(string pageName)
        {
            var user = User;
            var isAuthorized = await _pageAuthorizationService.IsUserAuthorizedForPage(pageName, user);
            return Ok(isAuthorized);
        }
    }
}
