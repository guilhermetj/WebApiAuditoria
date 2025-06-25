using WebApiAuditoria.Models;

namespace WebApiAuditoria.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();

    }
}
