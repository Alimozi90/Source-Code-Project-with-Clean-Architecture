using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_Shop.Application.Contracts.Identity;
using N_Shop.Application.Models.Identity;

namespace N_Shop.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseModel>> Login(AuthRequestModel authRequestModel)
        {
            return Ok(await _authService.Login(authRequestModel));
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponseModel>> Register(RegistrationRequestModel registrationRequestModel)
        {
            return Ok(await _authService.Register(registrationRequestModel));
        }
    }
}
