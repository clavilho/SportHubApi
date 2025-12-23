using Microsoft.AspNetCore.Mvc;
using SportHubApi.Domain.Entities;
using SportHubApi.Domain.Services;

namespace SportHubApi.Controllers
{
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService _userService)
        {
            this._userService = _userService;
        }

        [HttpGet("CadastroUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] User usuario)
        {
            await _userService.CreateAsync(usuario);

            return Ok(usuario);
        }
    }
}
