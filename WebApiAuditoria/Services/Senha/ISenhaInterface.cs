using WebApiAuditoria.Models;

namespace WebApiAuditoria.Services.Senha
{
    public interface ISenhaInterface
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificarSenha(string senha, byte[] senhaHash, byte[] senhaSalt);
        string GerarToken(UsuarioModel usuario);

    }
}
