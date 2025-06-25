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
    }
}
