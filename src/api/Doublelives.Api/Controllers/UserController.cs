using Doublelives.Api.Infrastructure;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    [Route("api/user")]
    public class UserController : AuthControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IWorkContextAccessor workContextAccessor)
            : base(workContextAccessor)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("getToken")]
        public IActionResult GetToken()
        {
            var token = _userService.GenerateToken("2069b03a-9167-455c-9db8-5846334e5f20");

            return Ok(token);
        }

        [HttpGet("useToken")]
        public IActionResult UseToken()
        {
            var x = WorkContext;
            var isAuthenticated = User.Identity.IsAuthenticated;

            return Ok(isAuthenticated);
        }
    }
}