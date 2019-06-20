using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySetupASPNetCoreAPI.Contracts.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySetupASPNetCoreAPI.Controllers.V1
{
    //[Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class RestrictedController : ControllerBase
    {
        [HttpGet(ApiRoutes.Restricted.Test)]
        public IActionResult Get()
        {
            return Ok(new { Status = "Authorized"});
        }
    }
}