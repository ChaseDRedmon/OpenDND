using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenDND.Models;
using Serilog;

namespace OpenDND.Controllers
{
    public interface IRegisterController
    {
        Task<IActionResult> Register([FromBody] User user);
    }
    
    [Authorize]
    [Route("~/api")]
    public class RegisterController : Controller, IRegisterController
    {
        // TODO: Fix authorization service here
        internal protected IAuthorizationService AuthorizationService { get; }

        public RegisterController(IAuthorizationService authorizationService)
        {
            AuthorizationService = authorizationService;
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            Log.Information("!!!!!!!!!Received credentials request!!!!!!!!");
            
            
            
            
            return Accepted();
        }
    }
}