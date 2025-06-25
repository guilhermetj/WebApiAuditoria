using Azure;
using Microsoft.EntityFrameworkCore;
using WebApiAuditoria.Data;
using WebApiAuditoria.Models;

namespace WebApiAuditoria.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<UsuarioModel>> AtualizarUsuario(int id, UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsuarioModel>> CriarUsuario(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<bool>> DeletarUsuario(int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    response.Status = false;
                    response.Mensagem = "Usuário não encontrado.";
                    return response;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                response.Mensagem = $"Usuário {usuario.Nome} {usuario.Sobrenome} deletado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao Deletar usuários: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                if (usuarios.Count <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhum usuário encontrado.";
                    return response;
                }
                response.Dados = usuarios;
                response.Mensagem = "Usuários listados com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao listar usuários: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> ObterUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {

                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhum usuário encontrado.";
                    return response;
                }
                response.Dados = usuario;
                response.Mensagem = "Usuário listado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao lista usuário: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
    }
}
