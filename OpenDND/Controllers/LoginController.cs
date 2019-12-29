using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenDND.Models;
using OpenDND.Services.Core;
using Serilog;

namespace OpenDND.Controllers
{
    public interface ILoginController
    {
        Task<IActionResult> Login([FromBody] User user);
    }
    
    //[ValidateAntiForgeryToken]
    //[Authorize]
    [Route("~/api")]
    public class LoginController : ControllerBase, ILoginController
    {
        //internal protected IAuthorizationService AuthorizationService { get; }
        internal protected IUserService UserService { get; }

        public LoginController(IUserService userService)
        {
            //AuthorizationService = authorizationService;
            UserService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            Log.Information("!!!!!!!!!Received credentials request!!!!!!!!");
            
            var entity = UserService.Authenticate(user.Username, user.Password);

            if (entity == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(user);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  UserService.GetAll();
            return Ok(users);
        }
    }
}