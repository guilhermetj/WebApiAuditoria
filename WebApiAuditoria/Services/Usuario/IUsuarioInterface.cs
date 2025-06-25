using WebApiAuditoria.Dto.Login;
using WebApiAuditoria.Dto.Usuario;
using WebApiAuditoria.Models;

namespace WebApiAuditoria.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> ObterUsuarioPorId(int id);
        Task<ResponseModel<UsuarioModel>> CriarUsuario(UsuarioCriacaoDto usuarioDto);
        Task<ResponseModel<UsuarioModel>> AtualizarUsuario(UsuarioEdicaoDto usuarioDto);
        Task<ResponseModel<bool>> DeletarUsuario(int id);
        Task<ResponseModel<UsuarioModel>> LoginUsuario(UsuarioLoginDto usuarioLoginDto);

    }
}
