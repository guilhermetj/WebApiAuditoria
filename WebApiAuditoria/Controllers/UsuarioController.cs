using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAuditoria.Services.Usuario;

namespace WebApiAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioInterface _usuarioService;
        public UsuarioController(IUsuarioInterface usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var response = await _usuarioService.ListarUsuarios();
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuarioPeloId(int id)
        {
            var response = await _usuarioService.ObterUsuarioPorId(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var response = await _usuarioService.DeletarUsuario(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
