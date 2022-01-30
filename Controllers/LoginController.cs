using AuthDemo.DTOs;
using AuthDemo.Models;
using AuthDemo.Repositories;
using AuthDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AuthDemo.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly Settings _settings;
        public LoginController(IOptions<Settings> options)
        {
            _settings = options.Value;
        }

        [HttpPost]
        public ActionResult<UserTokenResponse> Login([FromBody]UserLoginDto userLogin)
        {
            var user = UserRepository.GetUser(userLogin);

            if(user == null)
                return BadRequest("Usuário e/ou senha inválidos");

            string userToken = TokenService.GenerateToken(user, _settings);

            UserTokenResponse response = new(){
                Name = user.Name,
                Token = userToken
            };

            return Ok(response);
        }
    }
}