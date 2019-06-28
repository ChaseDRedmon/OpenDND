using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OpenDND.Models;

namespace OpenDND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public async Task<IActionResult> UserLogin([FromBody] Login login)
        {


            return Unauthorized();
        }
    }
}