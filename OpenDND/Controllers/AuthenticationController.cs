using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenDND.Models;
using OpenDND.Services.Handlers;
using Serilog;

namespace OpenDND.Controllers
{
    public interface IAuthenticationController
    {
        Task<IActionResult> Authenticate([FromBody] Credentials credentials);
    }
    
    [Authorize]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase, IAuthenticationController
    {
        internal protected AuthenticationHandler AuthenticationHandler { get; }

        public AuthenticationController(AuthenticationHandler authenticationHandler)
        {
            AuthenticationHandler = authenticationHandler;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate([FromBody] Credentials credentials)
        {
            Log.Information("Received employee credentials request");
            
            throw new NotImplementedException();
        }
    }
}