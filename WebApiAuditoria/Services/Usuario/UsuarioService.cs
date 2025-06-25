using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using WebApiAuditoria.Data;
using WebApiAuditoria.Dto.Usuario;
using WebApiAuditoria.Models;
using WebApiAuditoria.Services.Senha;

namespace WebApiAuditoria.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly IMapper _mapper;
        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface, IMapper mapper)
        {
            _context = context;
            _senhaInterface = senhaInterface;
            _mapper = mapper;
        }

        public async Task<ResponseModel<UsuarioModel>> AtualizarUsuario(UsuarioEdicaoDto usuarioDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(usuarioDto.Id);

                if (usuario == null)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhum usuário encontrado.";
                    return response;
                }
                usuario.Usuario = usuarioDto.Usuario;
                usuario.Nome = usuarioDto.Nome;
                usuario.Sobrenome = usuarioDto.Sobrenome;
                usuario.Email = usuarioDto.Email;
                usuario.DataAlteracao = DateTime.Now;

                _context.Usuarios.Update(usuario);

                await _context.SaveChangesAsync();

                response.Mensagem = $"Usuário {usuario.Nome} {usuario.Sobrenome} editado com sucesso";
                response.Dados = usuario;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao Editar usuário: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> CriarUsuario(UsuarioCriacaoDto usuarioDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (!VerificaEmailRepetido(usuarioDto))
                {
                    response.Status = false;
                    response.Mensagem = "Email já cadastrado.";
                    return response;
                }
                _senhaInterface.CriarSenhaHash(usuarioDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioDto);
                usuario.SenhaHash = senhaHash;
                usuario.SenhaSalt = senhaSalt;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário Cadastrado com Sucesso";
                response.Dados = usuario;   
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao Criar usuário: {ex.Message}";
                response.Status = false;
                return response;
            }
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

        private bool VerificaEmailRepetido(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(item => item.Email == usuarioCriacaoDto.Email);
            if (usuario != null)
            {
                return false; // Email já existe
            }
            return true;
        }
    }
}
