using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAuditoria.Dto.Login;
using WebApiAuditoria.Dto.Usuario;
using WebApiAuditoria.Services.Usuario;

namespace WebApiAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public LoginController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioCriacaoDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Dados do usuário não podem ser nulos.");
            }
            var response = await _usuarioInterface.CriarUsuario(usuarioDto);
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto LoginDto)
        {
            if (LoginDto == null)
            {
                return BadRequest("Dados do usuário não podem ser nulos.");
            }
            var response = await _usuarioInterface.LoginUsuario(LoginDto);
            return Ok(response);
        }
    }
}
