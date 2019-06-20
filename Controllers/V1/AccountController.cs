using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySetupASPNetCoreAPI.Contracts.V1;
using EasySetupASPNetCoreAPI.Controllers.V1.Request;
using EasySetupASPNetCoreAPI.Controllers.V1.Response;
using EasySetupASPNetCoreAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySetupASPNetCoreAPI.Controllers.V1
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(ApiRoutes.Account.Login)]
        [Produces(typeof(AuthenticationResult))]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var authResponse = await _accountService.LoginAsync(model.Email, model.Password);
            return Ok(authResponse);
        }

        [HttpPost(ApiRoutes.Account.Register)]
        [Produces(typeof(AuthenticationResult))]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthenticationResult
                {
                    Errors = ModelState.Values.SelectMany(c=>c.Errors.Select(a=>a.ErrorMessage))
                });
            }
            var authResponse = await _accountService.RegisterAsync(register.Email, register.Password, register.FirstName, register.LastName, register.Phone);
            return Ok(authResponse);
        }

        
    }  
}