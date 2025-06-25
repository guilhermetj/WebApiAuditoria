using WebApiAuditoria.Models;

namespace WebApiAuditoria.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> ObterUsuarioPorId(int id);
        Task<ResponseModel<UsuarioModel>> CriarUsuario(UsuarioModel usuario);
        Task<ResponseModel<UsuarioModel>> AtualizarUsuario(int id, UsuarioModel usuario);
        Task<ResponseModel<bool>> DeletarUsuario(int id);

    }
}
